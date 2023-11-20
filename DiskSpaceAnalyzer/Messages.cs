using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiskSpaceAnalyzer
{
    public record Message();

    public record AddFolderMessage(DirectoryInfo folder, DirectoryInfo? parent) : Message;

    public record IncrementSize(DirectoryInfo folder, long byValue) : Message;
}
