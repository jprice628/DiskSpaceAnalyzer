namespace DiskSpaceAnalyzer
{
    partial class Form1
    {
        // To avoid potential threading issues, these two variables will only
        // be accessed directly by the worker thread. When updating the UI, use
        // the state parameter on the synchronization's Post method.
        DateTime lastProgressUpdate;
        long directoriesAdded;
        long filesAdded;

        void BeginTrackingProgress()
        {
            directoriesAdded = 0;
            filesAdded = 0;
            ProgressLabel.Text = "Starting...";
            lastProgressUpdate = DateTime.Now;
        }

        void EndTrackingProgress()
        {
            // This method is called from the main UI thread before work begins,
            // so the synchronization context is not needed.

            // Since the work is done, it should be safe to access the
            // directoriesAdded and filesAdded variables here.

            ProgressLabel.Text = $"Complete: {directoriesAdded:N0} directories / {filesAdded:N0} files";
        }

        void IncrementDirectoriesAdded(long byValue)
        {
            // This is called by the worker, so the variable can be accessed
            // directly.
            directoriesAdded += byValue;

            PostProgressUpdate();
        }

        void IncrementFilesAdded(long byValue)
        {
            // This is called by the worker, so the variable can be accessed
            // directly.
            filesAdded += byValue;

            PostProgressUpdate();
        }

        void PostProgressUpdate()
        {
            // Avoid posting updates to the UI too frequently.
            if (DateTime.Now > lastProgressUpdate.AddSeconds(1)) 
            {
                syncContext.Post(UpdateProgressInfo, (directoriesAdded, filesAdded));                
                
                lastProgressUpdate = DateTime.Now;
            }
        }

        void UpdateProgressInfo(object? state)
        {
            // Caution: This method updates the UI, so use syncContext to invoke this
            // method on the UI thread.

            if (state is null)
            {
                throw new ArgumentNullException(nameof(state));
            }

            var info = ((long directoriesAdded, long filesAdded))state;

            ProgressLabel.Text = $"Working: {info.directoriesAdded:N0} directories / {info.filesAdded:N0} files";
        }
    }
}
