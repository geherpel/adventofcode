using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle11
{
    public class Monkey
    {
        public List<long> Items { get; set; } = new List<long>();
        public Helper.Operation Operation;
        public string OpNum;
        public int DivBy;
        public Monkey IfTrue;
        public int IfTrueNum;
        public Monkey IfFalse;
        public int IfFalseNum;
        public long inspected = 0;

        public Monkey(string starting, string opLine, string divLine, string trueLine, string falseLine)
        {
            foreach(var item in starting.Replace("Starting items:","").Trim().Split(", "))
            {
                Items.Add(long.Parse(item));
            }

            var op = opLine.Replace("Operation: new = old", "").Trim().Split(" ");
            if (op[0] == "+")
            {
                Operation = Helper.Operation.Add;
            }
            else
            {
                Operation = Helper.Operation.Multiply;
            }

            OpNum = op[1];

            DivBy = int.Parse(divLine.Replace("Test: divisible by ", "").Trim());
            IfTrueNum = int.Parse(trueLine.Replace("If true: throw to monkey", "").Trim());
            IfFalseNum = int.Parse(falseLine.Replace("If false: throw to monkey", "").Trim());
        }

        public void SetMonkeys(List<Monkey> monkeys)
        {
            IfTrue = monkeys[IfTrueNum];
            IfFalse = monkeys[IfFalseNum];
        }

        public void PerformTests(bool div, int commonNum)
        {
            for (var i = 0; i < Items.Count; i++)
            {
                inspected++;

                var item = Items[i];
                long test = 0;
                if (OpNum == "old")
                {
                    test = item;
                }
                else
                {
                    test = long.Parse(OpNum);
                }

                if (Operation == Helper.Operation.Add)
                {
                    item += test;
                }
                else
                {
                    item *= test;
                }

                if(div)
                    item = Convert.ToInt64(Math.Floor(item / 3.0));

                if (item % DivBy == 0)
                {
                    IfTrue.Items.Add(item % commonNum);
                }
                else
                {
                    IfFalse.Items.Add(item % commonNum);
                }
            }
            Items.Clear();
        }
    }
}
