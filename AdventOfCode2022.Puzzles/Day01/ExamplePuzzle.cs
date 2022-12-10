using AdventOfCode.Kit.Client.Models;

namespace AdventOfCode2022.Puzzles.Day01
{
    internal class ExamplePuzzle : Puzzle
    {
        public override (Answer First, Answer Second) Run(string[] lines)
        {
            foreach (string line in lines)
            { 
                Console.WriteLine(line);
            }
            var firstAnswer = new Answer { Value = 0, Description = "First answer" };
            var secondAnswer = new Answer { Value = 0, Description = "Second answer" };
            return (firstAnswer, secondAnswer);
        }
    }
}
