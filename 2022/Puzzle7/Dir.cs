namespace Puzzle7
{
    public class Dir
    {
        public string Name { get; set; }
        public Dir Parent { get; set; }
        public List<Dir> Dirs { get; set; } = new List<Dir>();
        public List<Stuff>  Files { get; set; } = new List<Stuff>();


        private int _size = 0;
        public int Size
        {
            get
            {
                if (_size == 0)
                {
                    var fileSize = Files.Select(f => f.Size).Sum();
                    var dirSize = Dirs.Select(f => f.Size).Sum();
                    _size = fileSize + dirSize;
                }

                return _size;
            }
        }

        public Dir(string name)
        {
            Name = name;
        }

        public Dir(string name, Dir parent)
        {
            Name = name;
            Parent = parent;
        }

        public string Print(string indent = "")
        {
            var ret = $"{indent}{Name} (dir, size={Size}){Environment.NewLine}";
            foreach (var dir in Dirs)
            {
                ret += dir.Print(indent + "\t");
            }

            foreach (var file in Files)
            {
                ret += file.Print(indent + "\t");
            }
            return ret;
        }

        public int ContainsLTE(int sizeComp)
        {
            int i = 0;
            foreach (var dir in Dirs)
            {
                i += dir.ContainsLTE(sizeComp);
            }
            if (Size < sizeComp)
            {
                i += Size;
            }

            return i;
        }

        public int ClosestDir(int sizeComp)
        {
            int i = int.MaxValue;
            foreach (var dir in Dirs)
            {
                var dirVal = dir.ClosestDir(sizeComp);
                if (sizeComp <= dirVal && i > dirVal)
                {
                    i = dirVal;
                }
            }

            if (sizeComp <= Size && i > Size)
            {
                i = Size;
            }

            return i;
        }
    }
}
