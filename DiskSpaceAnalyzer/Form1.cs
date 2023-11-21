namespace DiskSpaceAnalyzer
{
    public partial class Form1 : Form
    {
        readonly Random random;
        readonly SynchronizationContext syncContext;

        public Form1()
        {
            InitializeComponent();

            random = new Random();

            syncContext = SynchronizationContext.Current ??
                throw new InvalidOperationException("Curent synchronization context is null.");
        }

        async void StartScanMenuItem_Click(object sender, EventArgs e)
        {
            StartScanMenuItem.Enabled = false;
            FolderView.Nodes.Clear();
            BeginTrackingProgress();

            await Task.Run(PerformScan).ConfigureAwait(true);

            StartScanMenuItem.Enabled = true;
            EndTrackingProgress();
        }

        void PerformScan()
        {
            for (var i = 0; i < 50; i++)
            {
                Thread.Sleep(200);
                IncrementDirectoriesAdded(random.Next(10));
                IncrementFilesAdded(random.Next(10));
            }
        }
    }
}