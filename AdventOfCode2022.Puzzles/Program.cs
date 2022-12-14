using AdventOfCode.Kit.Console;
using AdventOfCode2022.Puzzles;

namespace AdventOfCode2022.Puzzles;
class Program
{
    static void Main(string[] args)
    {
        var app = AdventOfCodeConsole.Instance;

        app.StartYear(2022, year => {
            year.Submit<CalorieCountingPuzzle>().ForDay(1);
            year.Submit<RockPaperScissorsPuzzle>().ForDay(2);
            year.Submit<RucksackReorganizationPuzzle>().ForDay(3);
            year.Submit<CampCleanupPuzzle>().ForDay(4);
        });

        app.Run(args);
    }
}