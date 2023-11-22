using DiskSpaceAnalyzer;
;

var path = @"C:\Users\Jeremy\Desktop\DiskSpaceAnalyzer";
var stream = new PathStream(path);

while(!stream.EndOfStream)
{
    var @event = stream.Read();

    switch (@event)
    {
        case DirectoryAddedEvent daEvent:
            Console.WriteLine($"Directory Added: {daEvent.Directory.Name}");
            break;
        case FileAddedEvent faEvent:
            Console.WriteLine($"File Added: {faEvent.File.Name}");
            break;
        default:
            throw new ArgumentOutOfRangeException(nameof(@event));
    }
}

