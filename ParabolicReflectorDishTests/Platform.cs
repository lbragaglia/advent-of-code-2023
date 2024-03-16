using System.Text.RegularExpressions;

namespace ParabolicReflectorDishTests;

public class Platform : IPlatform
{
    private readonly int _rowSize;
    public string Shape { get; }

    public Platform(string shape)
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

    public Platform TiltNorth()
    {
        var currentShape = Shape;
        var newShape = Roll(currentShape);
        while (newShape != currentShape)
        {
            currentShape = newShape;
            newShape = Roll(currentShape);
        }

        return new Platform(newShape);
    }

    private string Roll(string platformShape) =>
        Regex.Replace(platformShape, @$"(\.)(.{{{_rowSize + 1}}})(O)", "$3$2$1",
            RegexOptions.Compiled | RegexOptions.Singleline);
}