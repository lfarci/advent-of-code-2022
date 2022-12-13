namespace AdventOfCode2022.Puzzles
{
    public class Range
    {
        public int Start { get; set; }
        public int End { get; set; }

        // Constructor
        public Range(int start, int end)
        {
            Start = start;
            End = end;
        }

        public bool Contains(Range other)
        {
            return Start <= other.Start && End >= other.End;
        }

        public bool Overlaps(Range other)
        {
            return Start <= other.End && other.Start <= End;
        }
    }
}