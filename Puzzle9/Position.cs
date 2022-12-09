using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle9
{
    public class Position
    {
        public int x { get; set; }
        public int y { get; set; }

        public bool EqualPos(Position pos)
        {
            return x == pos.x && y == pos.y;
        }

        public bool Adjacent(Position pos)
        {
            return pos.x >= x - 1 && pos.x <= x + 1 && pos.y >= y - 1 &&  pos.y <= y + 1;
        }

        public Position Copy()
        {
            return (Position)this.MemberwiseClone();
        }
    }
}
