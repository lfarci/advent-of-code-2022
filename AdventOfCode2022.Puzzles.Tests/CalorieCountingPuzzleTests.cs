using AdventOfCode2022.Puzzles.Day01;

namespace AdventOfCode2022.Puzzles.Tests
{
    public class CalorieCountingPuzzleTests
    {
        private static string[] sample = new string[]
        {
            "1000",
            "2000",
            "3000",
            "",
            "4000",
            "",
            "5000",
            "6000",
            "",
            "7000",
            "8000",
            "9000",
            "",
            "10000",
        };

        [Fact]
        public void Run_Sample_ReturnsHighestAmountOfCaloriesAsFirstAnswer()
        {
            var puzzle = new CalorieCountingPuzzle();
            var answers = puzzle.Run(sample);
            Assert.Equal(24000, answers.First.Value);
        }

        [Fact]
        public void Run_EmptyInputFile_ReturnsSecondValueAsZero()
        {
            var puzzle = new CalorieCountingPuzzle();
            var answers = puzzle.Run(sample);
            Assert.Equal(0, answers.Second.Value);
        }
    }
}