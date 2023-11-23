namespace DiskSpaceAnalyzer
{
    partial class Form1
    {
        static readonly Dictionary<char, int> imageIndex = new()
        {
            { 'D', 0 },
            { 'F', 1 }
        };

        void PathView_DoubleClick(object sender, EventArgs e)
        {
            if (PathView.SelectedItems.Count == 0)
            {
                return;
            }

            if (PathView.SelectedItems[0].Text == ".")
            {
                return;
            }

            var selectedNode = (PathNode)PathView.SelectedItems[0].Tag;            

            if (selectedNode.NodeType == 'F')
            {
                return;
            }

            Navigate(selectedNode);
        }

        void Navigate(PathNode node)
        {
            PathView.Items.Clear();

            // Show full name.
            AddressBar.Text = node.FullName;

            // Show the self node.
            var self = NewListViewItem(".", node.Size, node);
            PathView.Items.Add(self);

            // Show the parent node.
            if (node.Parent is not null)
            {
                var parent = NewListViewItem("..", node.Parent.Size, node.Parent);
                PathView.Items.Add(parent);
            }

            // Show the children.
            foreach (var item in node.Children)
            {
                var child = NewListViewItem(item.Name, item.Size, item);
                PathView.Items.Add(child);
            }
        }

        static ListViewItem NewListViewItem(string name, long size, PathNode node)
        {
            var subItems = new[]
            {
                name,
                size.ToString("N0")
            };

            var item = new ListViewItem(subItems, imageIndex[node.NodeType])
            {
                Tag = node
            };

            return item;
        }
    }
}
