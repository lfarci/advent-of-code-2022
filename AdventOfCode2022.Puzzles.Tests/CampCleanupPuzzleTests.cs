namespace AdventOfCode2022.Puzzles.Tests
{
    public class CampCleanupPuzzleTests
    {
        private static string[] sample = new string[]
        {
            "2-4,6-8",
            "2-3,4-5",
            "5-7,7-9",
            "2-8,3-7",
            "6-6,4-6",
            "2-6,4-8"
        };

        [Theory]
        [InlineData("2-4", 2, 4)]
        [InlineData("6-8", 6, 8)]
        [InlineData("2-3", 2, 3)]
        [InlineData("4-5", 4, 5)]
        [InlineData("5-7", 5, 7)]
        [InlineData("7-9", 7, 9)]
        void ParseSectionAssignment_ValidAssignment_ReturnsParsedSectionAssignment(string assignmentString, int start, int end)
        {
            var puzzle = new CampCleanupPuzzle();
            var range = puzzle.ParseSectionAssignment(assignmentString);
            Assert.Equal(start, range.Start);
            Assert.Equal(end, range.End);
        }

        [Theory]
        [InlineData(5, 7, 7, 9)]
        [InlineData(2, 8, 3, 7)]
        [InlineData(6, 6, 4, 6)]
        [InlineData(2, 6, 4, 8)]
        void Overlaps_OverlapingRange_ReturnsTrue(int firstStart, int firstEnd, int secondStart, int secondEnd)
        {
            Assert.True(new Range(firstStart, firstEnd).Overlaps(new Range(secondStart, secondEnd)));
        }

        [Theory]
        [InlineData(2, 4, 6, 8)]
        [InlineData(2, 3, 4, 5)]
        void Overlaps_NotOverlapingRange_ReturnsFalse(int firstStart, int firstEnd, int secondStart, int secondEnd)
        {
            Assert.False(new Range(firstStart, firstEnd).Overlaps(new Range(secondStart, secondEnd)));
        }

        [Fact]
        void Run_Sample_ReturnsSumOfErrorsPriorities()
        {
            var puzzle = new CampCleanupPuzzle();
            var answers = puzzle.Run(sample);
            Assert.Equal(2, answers.First.Value);
        }

        [Fact]
        public void Run_Sample_ReturnsSumOfGroupBadgePriorities()
        {
            var puzzle = new CampCleanupPuzzle();
            var answers = puzzle.Run(sample);
            Assert.Equal(4, answers.Second.Value);
        }
    }
}