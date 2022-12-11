using AdventOfCode.Kit.Client.Models;

namespace AdventOfCode2022.Puzzles
{
    internal class RockPaperScissorsPuzzle : Puzzle
    {
        private static IDictionary<string, Shape> shapes = new Dictionary<string, Shape>
        {
            { "A", Shape.Rock },
            { "X", Shape.Rock },
            { "B", Shape.Paper },
            { "Y", Shape.Paper },
            { "C", Shape.Scissors },
            { "Z", Shape.Scissors }
        };

        private static IDictionary<string, Outcome> outcomes = new Dictionary<string, Outcome>
        {
            { "Y", Outcome.Draw },
            { "X", Outcome.Defeat },
            { "Z", Outcome.Victory }
        };

        private bool IsVictory(Shape otherShape, Shape shape)
        {
            return (shape == Shape.Rock && otherShape == Shape.Scissors)
                || (shape == Shape.Paper && otherShape == Shape.Rock)
                || (shape == Shape.Scissors && otherShape == Shape.Paper);
        }

        internal Outcome GetRoundOutcome(Shape otherShape, Shape shape)
        {
            if (otherShape == shape)
            {
                return Outcome.Draw;
            }

            if (IsVictory(otherShape, shape))
            {
                return Outcome.Victory;
            }

            return Outcome.Defeat;
        }

        internal Shape GetRequiredShape(Shape otherShape, Outcome outcome)
        {
            if (outcome == Outcome.Draw)
            {
                return otherShape;
            }

            if (outcome == Outcome.Victory)
            {
                if (otherShape == Shape.Rock)
                {
                    return Shape.Paper;
                }

                if (otherShape == Shape.Paper)
                {
                    return Shape.Scissors;
                }

                return Shape.Rock;
            }

            if (otherShape == Shape.Rock)
            {
                return Shape.Scissors;
            }

            if (otherShape == Shape.Paper)
            {
                return Shape.Rock;
            }

            return Shape.Paper;
        }

        internal int GetRoundScore(Shape otherShape, Shape shape)
        {
            return (int)shape + (int)GetRoundOutcome(otherShape, shape);
        }

        internal int GetRoundScore(Shape otherShape, Outcome expextedOutcome)
        {
            var shape = GetRequiredShape(otherShape, expextedOutcome);
            return (int)shape + (int)GetRoundOutcome(otherShape, shape);
        }

        internal (Shape OtherShape, Shape Shape) ParseRound(string recommendation)
        {
            var tokens = recommendation.Split(" ");
            return (shapes[tokens[0]], shapes[tokens[1]]);
        }

        internal (Shape Shape, Outcome Outcome) ParseExpectedOutcome(string round)
        {
            var tokens = round.Split(" ");
            return (shapes[tokens[0]], outcomes[tokens[1]]);
        }

        internal int GetTotalScoreForGivenRounds(string[] strategyGuide)
        {
            int totalScore = 0;

            foreach (string recommendation in strategyGuide)
            {
                var round = ParseRound(recommendation);
                totalScore += GetRoundScore(round.OtherShape, round.Shape);
            }

            return totalScore;
        }

        internal int GetTotalScoreForExpectedOutcomes(string[] strategyGuide)
        {
            int totalScore = 0;

            foreach (string recommendation in strategyGuide)
            {
                var expectation = ParseExpectedOutcome(recommendation);
                totalScore += GetRoundScore(expectation.Shape, expectation.Outcome);
            }

            return totalScore;
        }

        public override (Answer First, Answer Second) Run(string[] lines)
        {
            return (
                new Answer
                {
                    Value = GetTotalScoreForGivenRounds(lines),
                    Description = "Total score for list of rounds"
                },
                new Answer
                {
                    Value = GetTotalScoreForExpectedOutcomes(lines),
                    Description = "Total score for expected outcomes"
                }
            );
        }
    }
}