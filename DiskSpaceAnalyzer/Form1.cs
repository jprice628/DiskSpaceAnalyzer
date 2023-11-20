namespace DiskSpaceAnalyzer
{
    public partial class Form1 : Form
    {
        readonly Random random;
        readonly SynchronizationContext syncContext;
        readonly ProgressController progress;

        public Form1()
        {
            InitializeComponent();

            random = new Random();
            
            syncContext = SynchronizationContext.Current ?? throw new InvalidOperationException("Curent synchronization context is null.");
            progress = new ProgressController(ProgressLabel, ProgressBar, syncContext);
        }

        async void StartScanMenuItem_Click(object sender, EventArgs e)
        {
            StartScanMenuItem.Enabled = false;
            FolderView.Nodes.Clear();
            progress.Begin();

            await Task.Run(PerformScan).ConfigureAwait(true);

            StartScanMenuItem.Enabled = true;
            progress.Done();
        }

        void PerformScan()
        {
            for (var i = 0; i < 50; i++)
            {
                Thread.Sleep(200);
                progress.IncrementItemsFound(random.Next(100));
                progress.IncrementItemsCompleted();
            }
        }
    }
}