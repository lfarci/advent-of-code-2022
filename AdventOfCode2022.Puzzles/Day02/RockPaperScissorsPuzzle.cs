using System.Runtime.CompilerServices;
using AdventOfCode.Kit.Client.Models;

namespace AdventOfCode2022.Puzzles
{
    internal class RockPaperScissorsPuzzle : Puzzle
    {
        public override (Answer First, Answer Second) Run(string[] lines)
        {
            return (
                new Answer
                {
                    Value = 0,
                    Description = "First"
                },
                new Answer
                {
                    Value = 0,
                    Description = "Second"
                }
            );
        }
    }
}