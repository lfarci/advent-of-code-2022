using System.Runtime.CompilerServices;
using AdventOfCode.Kit.Client.Models;

namespace AdventOfCode2022.Puzzles.Day01
{
    internal class CalorieCountingPuzzle : Puzzle
    {
        internal int FindHighestAmoumtOfCalories(string[] lines)
        {
            var totalCalories = new List<int>();
            int currentElfCalories = 0;

            foreach (string line in lines)
            {
                if (string.IsNullOrEmpty(line.Trim()))
                {
                    totalCalories.Add(currentElfCalories);
                    currentElfCalories = 0;
                }
                else
                {
                    currentElfCalories += int.Parse(line);
                }
            }

            return totalCalories.Max();
        }

        public override (Answer First, Answer Second) Run(string[] lines)
        {
            var secondAnswer = new Answer { Value = 0, Description = "Second answer" };
            return (new Answer
            {
                Value = FindHighestAmoumtOfCalories(lines),
                Description = "Highest amount of calories"
            }, secondAnswer);
        }
    }
}