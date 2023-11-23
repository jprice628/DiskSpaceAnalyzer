namespace DiskSpaceAnalyzer
{
    partial class Form1
    {
        readonly SynchronizationContext syncContext;
        readonly Dictionary<string, PathNode> pathIndex;
        
        string rootPath = string.Empty;

        async void StartScanButton_Click(object sender, EventArgs e)
        {
            PathSelectDialog.InitialDirectory = string.IsNullOrWhiteSpace(rootPath) ?
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop) :
                rootPath;
            var pathSelectResult = PathSelectDialog.ShowDialog(this);

            if (pathSelectResult != DialogResult.OK)
            {
                return;
            }

            rootPath = PathSelectDialog.SelectedPath.ToLowerInvariant();

            StartScanButton.Enabled = false;
            AddressBar.Text = string.Empty;
            PathView.Items.Clear();
            pathIndex.Clear();
            BeginTrackingProgress();

            await Task.Run(PerformScan).ConfigureAwait(true);

            StartScanButton.Enabled = true;
            EndTrackingProgress();
            Navigate(pathIndex[rootPath]);
        }

        void PerformScan()
        {
            var stream = new PathStream(rootPath);

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
            var parent = GetParentNode(directory.Parent);
            var node = new PathNode('D', directory.Name, directory.FullName, parent);            
            parent?.Children.Add(node);
            pathIndex.Add(directory.FullName.ToLowerInvariant(), node);
            IncrementDirectoriesAdded(1);
        }

        void OnFileAdded(FileInfo file)
        {
            var parent = GetParentNode(file.Directory) ?? 
                throw new InvalidOperationException("Files must have a parent node.");
            var node = new PathNode('F', file.Name, file.FullName, parent, file.Length);            
            parent.Children.Add(node);

            while (node.Parent is not null)
            {
                node.Parent.Size += file.Length;
                node = node.Parent;
            }

            IncrementFilesAdded(1);
        }

        PathNode? GetParentNode(DirectoryInfo? parent)
        {
            if (parent is null)
            {
                return null;
            }

            var parentPath = parent.FullName.ToLowerInvariant();

            if (pathIndex.TryGetValue(parentPath, out PathNode? parentNode))
            {
                return parentNode;
            }
            else
            {
                return null;
            }
        }
    }
}
