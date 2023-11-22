namespace DiskSpaceAnalyzer
{
    public class PathStream
    {
        readonly Queue<PathStreamEvent> eventQueue;

        public bool EndOfStream => !eventQueue.Any();

        public PathStream(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            var directory = new DirectoryInfo(path);

            if (!directory.Exists)
            {
                throw new ArgumentOutOfRangeException(nameof(path), "The specified path does not exist.");
            }

            eventQueue = new Queue<PathStreamEvent>();
            var @event = new DirectoryAddedEvent(directory);
            eventQueue.Enqueue(@event);
        }

        public PathStreamEvent Read()
        {
            if (EndOfStream)
            {
                throw new InvalidOperationException("The end of the stream has been reached.");
            }

            var @event = eventQueue.Dequeue();

            if (@event is DirectoryAddedEvent daEvent)
            {
                QueueEventsForSubdirectories(daEvent.Directory);
                QueueEventsForFiles(daEvent.Directory);
            }

            return @event;
        }

        void QueueEventsForSubdirectories(DirectoryInfo directory)
        {
            var subdirectories = directory.GetDirectories();

            foreach (var subdirectory in subdirectories)
            {
                if (AccessAllowed(subdirectory))
                {
                    var @event = new DirectoryAddedEvent(subdirectory);
                    eventQueue.Enqueue(@event);
                }
            }
        }

        bool AccessAllowed(DirectoryInfo directory)
        {
            try
            {
                directory.GetDirectories();
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
        }

        void QueueEventsForFiles(DirectoryInfo directory)
        {
            var files = directory.GetFiles();

            foreach (var file in files)
            {
                var @event = new FileAddedEvent(file);
                eventQueue.Enqueue(@event);
            }
        }
    }
}