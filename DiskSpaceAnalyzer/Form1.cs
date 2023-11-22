using System.IO;

namespace DiskSpaceAnalyzer
{
    public partial class Form1 : Form
    {
        readonly SynchronizationContext syncContext;
        readonly Dictionary<string, TreeNode> pathIndex;

        public Form1()
        {
            InitializeComponent();

            syncContext = SynchronizationContext.Current ??
                throw new InvalidOperationException("Curent synchronization context is null.");
            pathIndex = new Dictionary<string, TreeNode>();
        }

        async void StartScanMenuItem_Click(object sender, EventArgs e)
        {
            StartScanMenuItem.Enabled = false;
            PathView.Nodes.Clear();
            pathIndex.Clear();
            BeginTrackingProgress();

            await Task.Run(PerformScan).ConfigureAwait(true);

            StartScanMenuItem.Enabled = true;
            EndTrackingProgress();
        }

        void PerformScan()
        {
            // HACK: The user should supply the path.
            var path = @"C:\Users\Jeremy\Desktop\DiskSpaceAnalyzer";
            var stream = new PathStream(path);

            while (!stream.EndOfStream)
            {
                var @event = stream.Read();

                switch (@event)
                {
                    case DirectoryAddedEvent daEvent:
                        OnDirectoryAdded(daEvent.Directory);
                        break;
                    case FileAddedEvent faEvent:
                        OnFileAdded(faEvent.File);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(@event));
                }
            }
        }

        void OnDirectoryAdded(DirectoryInfo directory)
        {
            // All of the interaction with the pathIndex takes place on the
            // worker thread.

            var node = NewTreeNode(directory);
            var parentNode = GetParentNode(directory.Parent);
            syncContext.Post(AddNodeToPathView, (node, parentNode));
            pathIndex.Add(directory.FullName.ToLowerInvariant(), node);
            IncrementDirectoriesAdded(1);
        }

        void OnFileAdded(FileInfo file)
        {
            var node = NewTreeNode(file);
            var parentNode = GetParentNode(file.Directory);

            if (parentNode is null)
            {
                throw new InvalidOperationException("Files must have a parent node.");
            }

            syncContext.Post(AddNodeToPathView, (node, parentNode));
            IncrementFilesAdded(1);
        }

        TreeNode NewTreeNode(DirectoryInfo directory)
        {
            var tag = new PathViewNodeTag('D', directory.Name);
            var node = new TreeNode()
            {
                Text = tag.ToString(),
                Tag = tag
            };
            return node;
        }

        TreeNode NewTreeNode(FileInfo file)
        {
            var tag = new PathViewNodeTag('F', file.Name, file.Length);
            var node = new TreeNode()
            {
                Text = tag.ToString(),
                Tag = tag
            };
            return node;
        }

        TreeNode? GetParentNode(DirectoryInfo? parent)
        {
            if (parent is null)
            {
                return null;
            }

            var parentPath = parent.FullName.ToLowerInvariant();

            if (pathIndex.TryGetValue(parentPath, out TreeNode? parentNode))
            {
                return parentNode;
            }
            else
            {
                return null;
            }
        }

        void AddNodeToPathView(object? state)
        {
            // Caution: This method updates the UI, so use syncContext to invoke this
            // method on the UI thread.

            (var node, var parent) = ((TreeNode, TreeNode?))state!;

            if (parent is null)
            {
                PathView.Nodes.Add(node);
            }
            else
            {
                parent.Nodes.Add(node);
                UpdateSizeData(node);
            }
        }

        void UpdateSizeData(TreeNode node)
        {
            var rootTag = (PathViewNodeTag)node.Tag;
            var sizeIncrease = rootTag.Size;

            if (sizeIncrease == 0)
            {
                return;
            }

            while (node.Parent is not null)
            {
                var parentTag = (PathViewNodeTag)node.Parent.Tag;
                parentTag.IncrementSize(sizeIncrease);
                node.Parent.Text = parentTag.ToString();

                node = node.Parent;
            }
        }
    }
}