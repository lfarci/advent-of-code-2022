using System.Runtime.CompilerServices;
using AdventOfCode.Kit.Client.Models;

namespace AdventOfCode2022.Puzzles
{
    internal class CampCleanupPuzzle : Puzzle
    {

        internal Range ParseSectionAssignment(string assignment)
        {
            var tokens = assignment.Split('-');
            return new Range(int.Parse(tokens[0]), int.Parse(tokens[1]));
        }

        internal (Range First, Range Second) ParseSectionAssignmentPair(string assignmentPair)
        {
            var tokens = assignmentPair.Split(',');
            return (ParseSectionAssignment(tokens[0]), ParseSectionAssignment(tokens[1]));
        }

        internal int CountFullyContainedAssignments(string[] pairs)
        {
            return pairs
                .Select(p => ParseSectionAssignmentPair(p))
                .Where(p => p.First.Contains(p.Second) || p.Second.Contains(p.First))
                .Count();
        }

        internal int CountOverlapingAssignments(string[] pairs)
        {
            return pairs
                .Select(p => ParseSectionAssignmentPair(p))
                .Where(p => p.First.Overlaps(p.Second))
                .Count();
        }

        public override (Answer First, Answer Second) Run(string[] lines)
        {
            return (
                new Answer
                {
                    Value = CountFullyContainedAssignments(lines),
                    Description = "Count fully contained assignments"
                },
                new Answer
                {
                    Value = CountOverlapingAssignments(lines),
                    Description = "Sum of group badge priorities"
                }
            );
        }
    }
}