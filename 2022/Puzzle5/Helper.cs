namespace Puzzle5
{
    public static class Helper
    {
        public static List<Stack<char>> CreateStacks(int size)
        {
            var ret = new List<Stack<char>>();
            for (int i = 0; i < size; i++)
            {
                ret.Add(new Stack<char>());
            }
            return ret;
        }

        public static int SetStacks(int index, string[] text, List<Stack<char>> stacks)
        {
            var maxIndex = 0;
            if (!text[index].StartsWith(" 1"))
            {
                maxIndex = SetStacks(index + 1, text, stacks);
            }
            else
            {
                return index;
            }

            var line = text[index];
            var itemLoc = line.IndexOf('[');
            while (itemLoc >= 0)
            {
                var crate = line[itemLoc + 1];
                var stackLoc = itemLoc / 4;
                stacks[stackLoc].Push(crate);
                itemLoc = line.IndexOf('[', itemLoc+1);
            }

            return maxIndex;
        }
    }
}
