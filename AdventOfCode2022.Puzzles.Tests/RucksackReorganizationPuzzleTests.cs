namespace AdventOfCode2022.Puzzles.Tests
{
    public class RucksackReorganizationPuzzleTests
    {
        private static string[] sample = new string[]
        {
            "vJrwpWtwJgWrhcsFMMfFFhFp",
            "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
            "PmmdzqPrVvPwwTWBwg",
            "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
            "ttgJtRGJQctTZtZT",
            "CrZsJsPPZsGzwwsLwLmpwMDw"
        };

        [Theory]
        [InlineData("vJrwpWtwJgWrhcsFMMfFFhFp", "vJrwpWtwJgWr", "hcsFMMfFFhFp")]
        [InlineData("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", "jqHRNqRjqzjGDLGL", "rsFMfFZSrLrFZsSL")]
        [InlineData("PmmdzqPrVvPwwTWBwg", "PmmdzqPrV", "vPwwTWBwg")]
        void GetCompartments_ValidRucksack_ReturnsCompartments(string rucksack, string firstCompartment, string secondCompartment)
        {
            var puzzle = new RucksackReorganizationPuzzle();
            var compartments = puzzle.GetCompartments(rucksack);
            Assert.Equal(firstCompartment, compartments.First);
            Assert.Equal(secondCompartment, compartments.Second);
        }

        [Theory]
        [InlineData("vJrwpWtwJgWrhcsFMMfFFhFp", 'p')]
        [InlineData("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", 'L')]
        [InlineData("PmmdzqPrVvPwwTWBwg", 'P')]
        [InlineData("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", 'v')]
        [InlineData("ttgJtRGJQctTZtZT", 't')]
        [InlineData("CrZsJsPPZsGzwwsLwLmpwMDw", 's')]
        void FindError_ValidRucksack_ReturnsError(string rucksack, char expectedError)
        {
            var puzzle = new RucksackReorganizationPuzzle();
            var error = puzzle.FindError(rucksack);
            Assert.Equal(expectedError, error);
        }

        [Theory]
        [InlineData(new string[] {
                "vJrwpWtwJgWrhcsFMMfFFhFp",
                "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
                "PmmdzqPrVvPwwTWBwg"
            },
            'r'
        )]
        [InlineData(new string[] {
                "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
                "ttgJtRGJQctTZtZT",
                "CrZsJsPPZsGzwwsLwLmpwMDw"
            },
            'Z'
        )]
        void FindGroupBadge_ValidRucksack_ReturnsError(string[] group, char expectedBadge)
        {
            var puzzle = new RucksackReorganizationPuzzle();
            var badge = puzzle.FindGroupBadge(group);
            Assert.Equal(expectedBadge, badge);
        }

        [Theory]
        [InlineData('p', 16)]
        [InlineData('L', 38)]
        [InlineData('P', 42)]
        [InlineData('v', 22)]
        [InlineData('t', 20)]
        [InlineData('s', 19)]
        void GetItemTypePriority_Letter_ReturnsPriority(char error, int expectedPriority)
        {
            var puzzle = new RucksackReorganizationPuzzle();
            var priority = puzzle.GetItemTypePriority(error);
            Assert.Equal(expectedPriority, priority);
        }

        [Fact]
        void Run_Sample_ReturnsSumOfErrorsPriorities()
        {
            var puzzle = new RucksackReorganizationPuzzle();
            var answers = puzzle.Run(sample);
            Assert.Equal(157, answers.First.Value);
        }

        [Fact]
        public void Run_Sample_ReturnsSumOfGroupBadgePriorities()
        {
            var puzzle = new RucksackReorganizationPuzzle();
            var answers = puzzle.Run(sample);
            Assert.Equal(70, answers.Second.Value);
        }
    }
}