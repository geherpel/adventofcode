using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle2
{
    public static class Helper
    {
        public enum RPS
        {
            Rock = 1,
            Paper = 2,
            Scissors = 3
        }

        public enum Outcome
        {
            Lose = 0,
            Draw = 3,
            Win = 6
        }

        public static int CalcPoints(RPS opp, RPS you)
        {
            var points = (int)you;
            if ((opp == RPS.Rock && you == RPS.Paper) || (opp == RPS.Paper && you == RPS.Scissors) ||
                (opp == RPS.Scissors && you == RPS.Rock))
            {
                points += (int)Outcome.Win;
            }
            else if (opp == you)
            {
                points += (int)Outcome.Draw;
            }

            return points;
        }

        public static int CalcPoints(RPS opp, Outcome you)
        {
            var points = (int)you;
            if (you == Outcome.Draw)
            {
                points += (int)opp;
            }
            else if (you == Outcome.Win)
            {
                points += ((int)opp % 3) + 1;
            }
            else
            {
                points += ((int)opp + 1) % 3 + 1;
            }

            return points;
        }

        public static RPS MapLetters(char letter)
        {
            return letter switch
            {
                'A' or 'X' => RPS.Rock,
                'B' or 'Y' => RPS.Paper,
                _ => RPS.Scissors
            };
        }

        public static Outcome MapOutcome(char letter)
        {
            return letter switch
            {
                'X' => Outcome.Lose,
                'Y' => Outcome.Draw,
                _ => Outcome.Win
            };
        }
    }
}
