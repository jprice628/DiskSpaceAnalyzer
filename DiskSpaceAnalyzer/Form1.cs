namespace DiskSpaceAnalyzer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Defined in Form1.Scan.cs.
            syncContext = SynchronizationContext.Current ??
                throw new InvalidOperationException("Curent synchronization context is null.");
            pathIndex = new Dictionary<string, PathNode>();

            // Defined in Form1.ProgressTracking.cs
            lastProgressUpdate = DateTime.MinValue;
            directoriesAdded = 0;
            filesAdded = 0;

            // Sorting
            PathView.ListViewItemSorter = new PathViewSorter();
        }
    }
}