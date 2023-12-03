using Microsoft.VisualBasic;

namespace Puzzle9
{
    public class Grid
    {
        public Position Head { get; set; }
        public List<Position> Tails { get; set; } = new List<Position>();

        public List<Position> TailVisited { get; set; } = new List<Position>();
        public List<Position> HeadVisited { get; set; } = new List<Position>();
        public int VisitedCount { get; set; }

        public Grid (int size=2)
        {
            //set up positions
            Head = new Position()
            {
                x = 0,
                y = 0
            };
            for (int i = 0; i < size-1; i++)
            {
                Tails.Add(new Position()
                {
                    x = 0,
                    y = 0
                });
            }
            TailVisited.Add(Tails[Tails.Count()-1].Copy());
        }

        public void MoveHead(char dir)
        {
            if (dir == 'D')
            {
                Head.y--;
            }
            else if (dir == 'U')
            {
                Head.y++;
            }
            else if (dir == 'L')
            {
                Head.x--;
            }
            else if (dir == 'R')
            {
                Head.x++;
            }

            if (!HeadVisited.Exists(v => v.EqualPos(Head)))
            {
                HeadVisited.Add(Head.Copy());
            }

            var prevKnot = Head;
            foreach (var tail in Tails)
            {
                MoveTail(tail, prevKnot);
                prevKnot = tail;
            }

            if (!TailVisited.Exists(v => v.EqualPos(Tails[Tails.Count() - 1])))
            {
                TailVisited.Add(Tails[Tails.Count() - 1].Copy());
            }
        }

        public void MoveTail(Position tail, Position prevKnot)
        {
            if (!tail.Adjacent(prevKnot))
            {
                int x = 0;
                int y = 0;
                if (prevKnot.x != tail.x)
                {
                    x = (prevKnot.x - tail.x) / Math.Abs(prevKnot.x - tail.x);
                }

                if (prevKnot.y != tail.y)
                {
                    y = (prevKnot.y - tail.y) / Math.Abs(prevKnot.y - tail.y);
                }

                tail.x += x;
                tail.y += y;
            }
        }

    }
}
