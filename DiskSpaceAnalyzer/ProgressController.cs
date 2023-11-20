using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiskSpaceAnalyzer
{
    // Organizes the mechanisms related to displaying progress.
    class ProgressController
    {

        readonly ToolStripStatusLabel progressLabel;
        readonly ToolStripProgressBar progressBar;
        readonly SynchronizationContext syncContext;

        // To avoid potential threading issues, itemsFound and itemsCompleted
        // will only be accessed directly by the worker thread. When updating
        // the UI, use the state parameter on the synchronization's Post method.
        long itemsFound;
        long itemsCompleted;

        public ProgressController(
            ToolStripStatusLabel progressLabel,
            ToolStripProgressBar progressBar, 
            SynchronizationContext syncContext)
        {
            this.progressLabel = progressLabel;
            this.progressBar = progressBar;
            this.syncContext = syncContext;

            itemsFound = 0;
            itemsCompleted = 0;
        }

        public void Begin()
        {
            // This method is called from the main UI thread before work begins,
            // so the synchronization context is not needed. It's also safe to update
            // the itemsFound and itemsCompleted values here.

            itemsFound = 0;
            itemsCompleted = 0;
            progressLabel.Text = "Starting...";
            progressBar.Value = 0;
        }

        public void IncrementItemsFound(long byValue)
        {
            // This is called by the worker, so the itemsFound variable can be
            // accessed directly.
            itemsFound += byValue;
        }

        public void IncrementItemsCompleted()
        {
            // This is called by the worker, so the itemsFound variable can be
            // accessed directly.
            itemsCompleted++;

            // Avoid flooding the UI with updates.
            if (itemsCompleted % 5 == 0)
            {
                syncContext.Post(UpdateProgressInfo, (itemsCompleted, itemsFound));
            }
        }

        void UpdateProgressInfo(object? state)
        {
            // This method is intended to update the UI while work is progressing.
            // It should be invoked using the synchronization context.

            // The state will never be null.
            var x = ((long itemsCompleted, long itemsFound))state!;

            progressLabel.Text = $"{x.itemsCompleted} completed / {x.itemsFound} found";

            progressBar.Value = x.itemsCompleted <= 0 ?
                0 : (int)(x.itemsCompleted % progressBar.Maximum);
        }

        public void Done()
        {
            // This method is called from the main UI thread before work begins,
            // so the synchronization context is not needed.

            progressLabel.Text = "Done!";
            progressBar.Value = progressBar.Maximum;
        }
    }
}
