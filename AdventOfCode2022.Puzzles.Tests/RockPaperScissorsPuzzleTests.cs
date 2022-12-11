namespace AdventOfCode2022.Puzzles.Tests
{
    public class RockPaperScissorsPuzzleTests
    {

        [Fact]
        public void Run_Sample_ReturnsHighestAmountOfCaloriesAsFirstAnswer()
        {
            var puzzle = new RockPaperScissorsPuzzle();
            var answers = puzzle.Run(Array.Empty<string>());
            Assert.Equal(0, answers.First.Value);
        }

        [Fact]
        public void Run_Sample_ReturnsSumOfTopThreeCaloriesAmounts()
        {
            var puzzle = new RockPaperScissorsPuzzle();
            var answers = puzzle.Run(Array.Empty<string>());
            Assert.Equal(0, answers.Second.Value);
        }
    }
}