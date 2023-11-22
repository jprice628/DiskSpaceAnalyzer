using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiskSpaceAnalyzer
{
    class PathViewNodeTag
    {
        static readonly char[] AllowedTypes = { 'D', 'F' };

        public char NodeType { get; private init; }

        public string Name { get; private init; }

        public long Size { get; private set; }

        public PathViewNodeTag(char nodeType, string name, long initialSize = 0)
        {
            if (!AllowedTypes.Contains(nodeType))
            {
                throw new ArgumentOutOfRangeException(nameof(nodeType));
            }

            NodeType = nodeType;

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;

            if (initialSize < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(initialSize));
            }

            Size = initialSize;
        }

        public void IncrementSize(long byValue)
        {
            Size += byValue;
        }

        public override string ToString()
        {
            var size = Size.ToString("N0").PadLeft(14, ' ');
            return $"{NodeType} {size} {Name}";
        }
    }
}
