using System.Text.RegularExpressions;

namespace ParabolicReflectorDishTests.Regex;

public class RegexPlatform : IPlatform
{
    private readonly int _rowSize;
    public string Shape { get; }

    public RegexPlatform(string shape)
    {
        Shape = shape;
        _rowSize = ToRows(shape)[0].Length;
    }

    private static string[] ToRows(string shape) =>
        shape.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

    public int CalculateTotalLoad()
    {
        var tilted = TiltNorth();
        var rows = ToRows(tilted.Shape);
        var currentRowLoad = rows.Length;
        var totalLoad = 0;
        foreach (var row in rows)
        {
            totalLoad += row.Count(x => x == IPlatform.RoundedRock) * currentRowLoad;
            currentRowLoad--;
        }

        return totalLoad;
    }

    public RegexPlatform TiltNorth()
    {
        var currentShape = Shape;
        var newShape = Roll(currentShape);
        while (newShape != currentShape)
        {
            currentShape = newShape;
            newShape = Roll(currentShape);
        }

        return new RegexPlatform(newShape);
    }

    private string Roll(string platformShape)
    {
        var emptySpace = System.Text.RegularExpressions.Regex.Escape(IPlatform.EmptySpace.ToString());
        var rowSize = _rowSize + 1;
        var roundedRock = System.Text.RegularExpressions.Regex.Escape(IPlatform.RoundedRock.ToString());

        return System.Text.RegularExpressions.Regex.Replace(platformShape,
            @$"({emptySpace})(.{{{rowSize}}})({roundedRock})",
            "$3$2$1",
            RegexOptions.Compiled | RegexOptions.Singleline);
    }
}