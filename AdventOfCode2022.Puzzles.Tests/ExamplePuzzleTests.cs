using AdventOfCode2022.Puzzles.Day01;

namespace AdventOfCode2022.Puzzles.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Run_EmptyInputFile_ReturnsFirstValueAsZero()
        {
            var puzzle = new ExamplePuzzle();
            var answers = puzzle.Run(Array.Empty<string>());
            Assert.Equal(0, answers.First.Value);
        }

        [Fact]
        public void Run_EmptyInputFile_ReturnsSecondValueAsZero()
        {
            var puzzle = new ExamplePuzzle();
            var answers = puzzle.Run(Array.Empty<string>());
            Assert.Equal(0, answers.Second.Value);
        }
    }
}