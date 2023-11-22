using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiskSpaceAnalyzer
{
    class PathViewSorter : IComparer
    {
        public int Compare(object? x, object? y)
        {
            if (x is null || y is null)
            {
                throw new ArgumentNullException("Neither object can be null.");
            }

            var xItem = (ListViewItem)x;
            var yItem = (ListViewItem)y;

            if (xItem.Text == ".") return -1;
            else if (yItem.Text == ".") return 1;
            else if (xItem.Text == "..") return -1;
            else if (yItem.Text == "..") return 1;
            
            var xNode = (PathNode)xItem.Tag;
            var yNode = (PathNode)yItem.Tag;

            if (xNode.Size > yNode.Size) return -1;
            else if (xNode.Size < yNode.Size) return 1;
            
            return StringComparer.OrdinalIgnoreCase.Compare(xNode.Name, yNode.Name);
        }
    }
}
