using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiskSpaceAnalyzer
{
    class PathNode
    {
        static readonly char[] AllowedTypes = { 'D', 'F' };

        public char NodeType { get; private init; }

        public string Name { get; private init; }

        public string FullName { get; private init; }

        public long Size { get; set; }

        public PathNode? Parent { get; private init; }

        public ICollection<PathNode> Children { get; private init; }

        public PathNode(char nodeType, string name, string fullName, PathNode? parent, long initialSize = 0)
        {
            if (!AllowedTypes.Contains(nodeType))
            {
                throw new ArgumentOutOfRangeException(nameof(nodeType));
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (string.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentNullException(nameof(fullName));
            }

            if (initialSize < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(initialSize));
            }

            NodeType = nodeType;
            Name = name;
            FullName = fullName;
            Size = initialSize;
            Parent = parent;
            Children = new List<PathNode>();
        }
    }
}
