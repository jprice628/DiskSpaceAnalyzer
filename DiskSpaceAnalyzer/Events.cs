namespace DiskSpaceAnalyzer
{
    public abstract record PathStreamEvent();

    public record DirectoryAddedEvent(DirectoryInfo Directory) : PathStreamEvent;

    public record FileAddedEvent(FileInfo File) : PathStreamEvent;
}
