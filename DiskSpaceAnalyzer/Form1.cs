namespace DiskSpaceAnalyzer
{
    public partial class Form1 : Form
    {
        int itemsFound;
        int itemsCompleted;

        readonly Random random;
        readonly SynchronizationContext syncContext;

        public Form1()
        {
            InitializeComponent();

            itemsFound = 0;
            itemsCompleted = 0;

            random = new Random();
            syncContext = SynchronizationContext.Current ?? throw new InvalidOperationException("Curent synchronization context is null.");
        }

        async void StartScanMenuItem_Click(object sender, EventArgs e)
        {
            StartScanMenuItem.Enabled = false;
            FolderView.Nodes.Clear();

            await Task.Run(PerformScan).ConfigureAwait(true);

            StartScanMenuItem.Enabled = true;
            ProgressBar.Value = ProgressBar.Maximum;
            ProgressLabel.Text = "Done!";
        }

        void PerformScan()
        {
            for (var i = 0; i < 50; i++)
            {
                Thread.Sleep(200);
                ItemsFound(random.Next(100));
                ItemCompleted();
            }
        }

        void ItemsFound(int numItemsFound)
        {
            itemsFound += numItemsFound;
        }

        void ItemCompleted()
        {
            itemsCompleted++;

            if (itemsCompleted % 5 == 0)
            {
                syncContext.Post(UpdateProgressInfo, (itemsCompleted, itemsFound));
            }
        }

        void UpdateProgressInfo(object? state)
        {
            var x = ((int itemsCompleted, int itemsFound))state!;
            ProgressLabel.Text = $"{x.itemsCompleted} completed / {x.itemsFound} found";

            ProgressBar.Value = x.itemsCompleted <= 0 ?
                0 : x.itemsCompleted % ProgressBar.Maximum;
        }

        public record Message();

        public record AddFolderMessage(DirectoryInfo folder, DirectoryInfo? parent) : Message;

        public record IncrementSize(DirectoryInfo folder, long byValue) : Message;
    }
}