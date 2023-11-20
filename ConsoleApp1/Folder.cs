using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Folder
    {
        readonly DirectoryInfo dirInfo;
        readonly IList<Folder> subfolders;
        readonly IList<File> files;

        public string Name => dirInfo.Name;

        public string FullName => dirInfo.FullName;

        public bool Exists => dirInfo.Exists;

        public Folder? Parent { get; private init; }

        public IEnumerable<Folder> Subfolders => subfolders;

        public IEnumerable<File> Files => files;

        public long Size { get; private set; }

        public Folder(
            DirectoryInfo dirInfo, 
            Folder? parent = null, 
            IEnumerable<Folder>? subfolders = null, 
            IEnumerable<File>? files = null)
        {
            this.dirInfo = dirInfo ?? throw new ArgumentNullException(nameof(dirInfo));
            Parent = parent;
            this.subfolders = subfolders?.ToList() ?? new List<Folder>();
            this.files = files?.ToList() ?? new List<File>();
            Size = 0;
        }

        public void Scan()
        {
            //
            // Files
            //
            files.Clear();
            foreach (var item in dirInfo.GetFiles())
            {
                var file = new File(item, this);
                files.Add(file);
            }

            //
            // Folders
            //
            subfolders.Clear(); 
            foreach (var item in dirInfo.GetDirectories())
            {
                var folder = new Folder(item, this);
                folder.Scan();
                subfolders.Add(folder);
            }

            //
            // Size
            //
            Size = subfolders.Sum(x => x.Size) + files.Sum(x => x.Size);
        }

        public override string ToString() => Name;

        public void Print(int indent = 0, int delta = 2)
        {
            var padding = string.Empty.PadLeft(indent);
            var text = $"{padding}D {Name} ({Size})";
            Console.WriteLine(text);

            foreach (var item in subfolders)
            {
                item.Print(indent + delta, delta);
            }

            foreach (var item in files)
            {
                item.Print(indent);
            }
        }
    }

    public class File
    {
        readonly FileInfo fileInfo;

        public string Name => fileInfo.Name;

        public string FullName => fileInfo.FullName;

        public long Size => fileInfo.Length;

        public Folder Parent { get; private init; }

        public File(FileInfo fileInfo, Folder parent)
        {
            this.fileInfo = fileInfo ?? throw new ArgumentNullException(nameof(fileInfo));
            Parent = parent;
        }

        public override string ToString() => Name;

        public void Print(int indent = 0)
        {
            var padding = string.Empty.PadLeft(indent);
            var text = $"{padding}F {Name} ({Size})";
            Console.WriteLine(text);
        }
    }
}
