using System.Runtime.CompilerServices;
using AdventOfCode.Kit.Client.Models;

namespace AdventOfCode2022.Puzzles
{
    internal class RucksackReorganizationPuzzle : Puzzle
    {

        internal (string First, string Second) GetCompartments(string rucksack)
        {
            var firstCompartmentLength = (int)rucksack.Length / 2;
            var secondCompartmentLength = (int)rucksack.Length - firstCompartmentLength;
            return (rucksack.Substring(0, firstCompartmentLength), rucksack.Substring(firstCompartmentLength, secondCompartmentLength));
        }

        internal char FindError(string rucksack)
        {
            var compartments = GetCompartments(rucksack);
            var candidates = compartments.First.Intersect(compartments.Second).ToArray();
            return candidates.Length == 1 ? candidates[0] : ' ';
        }

        internal char FindGroupBadge(string[] group)
        {
            if (group.Length != 3)
            {
                return ' ';
            }

            var candidates = group[0].Intersect(group[1]).Intersect(group[2]).ToArray();
            return candidates.Length == 1 ? candidates[0] : ' ';
        }

        internal int GetItemTypePriority(char error)
        {
            return (char.IsUpper(error) ? 27 : 1) + char.ToUpper(error) - 'A';
        }

        internal int SumErrorsPriorities(string[] rucksacks)
        {
            return rucksacks.Select(r => GetItemTypePriority(FindError(r))).Sum();
        }

        internal int SumGroupBadgePriorities(string[] rucksacks)
        {
            int groupSize = 3;
            int offset = 0;
            int sum = 0;
            while (offset < rucksacks.Length)
            {
                var group = new ArraySegment<string>(rucksacks, offset, groupSize);
                var badge = FindGroupBadge(group.ToArray());
                sum += GetItemTypePriority(badge);
                offset += groupSize;
            }
            return sum;
        }

        public override (Answer First, Answer Second) Run(string[] lines)
        {
            return (
                new Answer
                {
                    Value = SumErrorsPriorities(lines),
                    Description = "Sum of errors priorities"
                },
                new Answer
                {
                    Value = SumGroupBadgePriorities(lines),
                    Description = "Sum of group badge priorities"
                }
            );
        }
    }
}