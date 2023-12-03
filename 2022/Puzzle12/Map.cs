using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle12
{
    public class Map
    {
        public List<Node> Nodes { get; set; } = new List<Node>();
        public List<List<Node>> Grid { get; set; } = new List<List<Node>>();
    }
}
