using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle12
{
    public class Node
    {
        public char Elevation { get; set; }
        public bool Starting { get; set; }
        public bool Ending { get; set; }
        public bool Visited { get; set; }
        public int Distance { get; set; } = Int32.MaxValue;
        public List<Node> AdjacentNodes { get; set; } = new List<Node>();

        public Node(char elevation, bool aAsZero = false)
        {
            if (elevation == 'S')
            {
                Starting = true;
                Elevation = 'a';
                Distance = 0;
            }
            else if (elevation == 'E')
            {
                Ending = true;
                Elevation = 'z';
            }
            else
            {
                Elevation = elevation;
            }

            if (aAsZero && Elevation == 'a')
            {
                Distance = 0;
            }
        }

        public void AddAdjacent(Node node)
        {
            if (Elevation + 1 >= node.Elevation)
            {
                AdjacentNodes.Add(node);
            }
        }

        public void CalcAdjacent()
        {
            foreach (Node node in AdjacentNodes)
            {
                if (node.Distance > Distance + 1)
                {
                    node.Distance = Distance + 1;
                }
            }

            Visited = true;
        }
    }
}
