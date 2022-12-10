using System.Runtime.CompilerServices;
using AdventOfCode.Kit.Client.Models;

namespace AdventOfCode2022.Puzzles.Day01
{
    internal class CalorieCountingPuzzle : Puzzle
    {
        internal List<int> SumAmountOfCaloriesByElf(string[] lines)
        {
            var caloriesByElf = new List<int>();
            int currentElfCalories = 0;

            foreach (string line in lines)
            {

                if (string.IsNullOrEmpty(line.Trim()))
                {
                    caloriesByElf.Add(currentElfCalories);
                    currentElfCalories = 0;
                }
                else
                {
                    currentElfCalories += int.Parse(line);
                }

            }

            caloriesByElf.Add(currentElfCalories);

            return caloriesByElf;
        }

        internal int SumCaloriesForTopNElves(string[] lines, int elvesCount)
        {
            return SumAmountOfCaloriesByElf(lines)
                .OrderByDescending(c => c)
                .Take(elvesCount)
                .Sum();
        }

        public override (Answer First, Answer Second) Run(string[] lines)
        {
            var secondAnswer = new Answer { Value = 0, Description = "Second answer" };
            return (
            new Answer
            {
                Value = SumCaloriesForTopNElves(lines, 1),
                Description = "Highest amount of calories"
            },
            new Answer
            {
                Value = SumCaloriesForTopNElves(lines, 3),
                Description = "Sum of calories for the top 3 elves"
            });
        }
    }
}