namespace AdventOfCode2022.Puzzles.Tests
{
    public class RockPaperScissorsPuzzleTests
    {
        private static string[] sample = new string[] { "A Y", "B X", "C Z" };

        [Theory]
        [InlineData(Shape.Rock, Shape.Rock, Outcome.Draw)]
        [InlineData(Shape.Rock, Shape.Paper, Outcome.Victory)]
        [InlineData(Shape.Rock, Shape.Scissors, Outcome.Defeat)]
        [InlineData(Shape.Paper, Shape.Rock, Outcome.Defeat)]
        [InlineData(Shape.Paper, Shape.Paper, Outcome.Draw)]
        [InlineData(Shape.Paper, Shape.Scissors, Outcome.Victory)]
        [InlineData(Shape.Scissors, Shape.Rock, Outcome.Victory)]
        [InlineData(Shape.Scissors, Shape.Paper, Outcome.Defeat)]
        [InlineData(Shape.Scissors, Shape.Scissors, Outcome.Draw)]
        void GetRoundOutcome_ValidStrings_ReturnsExpectedScores(Shape opponent, Shape response, Outcome outcome)
        {
            var puzzle = new RockPaperScissorsPuzzle();
            Assert.Equal(outcome, puzzle.GetRoundOutcome(opponent, response));
        }

        [Theory]
        [InlineData(Shape.Rock, Outcome.Victory, Shape.Paper)]
        [InlineData(Shape.Rock, Outcome.Draw, Shape.Rock)]
        [InlineData(Shape.Rock, Outcome.Defeat, Shape.Scissors)]
        [InlineData(Shape.Paper, Outcome.Victory, Shape.Scissors)]
        [InlineData(Shape.Paper, Outcome.Draw, Shape.Paper)]
        [InlineData(Shape.Paper, Outcome.Defeat, Shape.Rock)]
        [InlineData(Shape.Scissors, Outcome.Victory, Shape.Rock)]
        [InlineData(Shape.Scissors, Outcome.Draw, Shape.Scissors)]
        [InlineData(Shape.Scissors, Outcome.Defeat, Shape.Paper)]
        void GetRequiredShape_ValidShapeAndOutcome_ReturnsExpectedShape(Shape otherShape, Outcome expectedOutcome, Shape shape)
        {
            var puzzle = new RockPaperScissorsPuzzle();
            Assert.Equal(shape, puzzle.GetRequiredShape(otherShape, expectedOutcome));
        }

        [Theory]
        [InlineData(Shape.Rock, Shape.Paper, 8)]
        [InlineData(Shape.Paper, Shape.Rock, 1)]
        [InlineData(Shape.Scissors, Shape.Scissors, 6)]
        void GetRoundScore_ValidStrings_ReturnsExpectedScores(Shape opponent, Shape response, int score)
        {
            var puzzle = new RockPaperScissorsPuzzle();
            Assert.Equal(score, puzzle.GetRoundScore(opponent, response));
        }

        [Theory]
        [InlineData("A Y", Shape.Rock, Shape.Paper)]
        [InlineData("B X", Shape.Paper, Shape.Rock)]
        [InlineData("C Z", Shape.Scissors, Shape.Scissors)]
        void ParseRound_ValidRounds_ReturnsParsedShapes(string round, Shape otherShape, Shape shape)
        {
            var puzzle = new RockPaperScissorsPuzzle();
            var shapes = puzzle.ParseRound(round);
            Assert.Equal(shape, shapes.Shape);
            Assert.Equal(otherShape, shapes.OtherShape);
        }

        [Theory]
        [InlineData("A Y", Shape.Rock, Outcome.Draw)]
        [InlineData("B X", Shape.Paper, Outcome.Defeat)]
        [InlineData("C Z", Shape.Scissors, Outcome.Victory)]
        void ParseExpectedOutcome_ValidRounds_ReturnsParsedShapeAndOutcome(string round, Shape shape, Outcome outcome)
        {
            var puzzle = new RockPaperScissorsPuzzle();
            var parsed = puzzle.ParseExpectedOutcome(round);
            Assert.Equal(shape, parsed.Shape);
            Assert.Equal(outcome, parsed.Outcome);
        }


        [Fact]
        void Run_Sample_ReturnsHighestAmountOfCaloriesAsFirstAnswer()
        {
            var puzzle = new RockPaperScissorsPuzzle();
            var answers = puzzle.Run(sample);
            Assert.Equal(15, answers.First.Value);
        }

        [Fact]
        public void Run_Sample_ReturnsSumOfTopThreeCaloriesAmounts()
        {
            var puzzle = new RockPaperScissorsPuzzle();
            var answers = puzzle.Run(sample);
            Assert.Equal(12, answers.Second.Value);
        }
    }
}