namespace Puzzle7
{
    public class Stuff
    {
        public string Name { get; set; }
        public int Size { get; set; }

        public Stuff(string name, int size)
        {
            Name = name;
            Size = size;
        }

        public string Print(string indent = "")
        {
            
            return $"{indent}{Name} (file, size={Size}){Environment.NewLine}";
        }
    }
}
