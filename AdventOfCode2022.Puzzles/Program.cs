using AdventOfCode.Kit.Console;
using AdventOfCode2022.Puzzles.Day01;

namespace AdventOfCode2022.Puzzles;
class Program
{
    static void Main(string[] args)
    {
        var app = AdventOfCodeConsole.Instance;

        app.StartYear(2022, year => {
            year.Submit<ExamplePuzzle>().ForDay(1);
        });

        app.Run(args);
    }
}