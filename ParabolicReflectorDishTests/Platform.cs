using System.Text.RegularExpressions;

namespace ParabolicReflectorDishTests;

public class Platform : IPlatform
{
    public string Shape { get; }

    public Platform(string shape)
    {
        Shape = shape;
    }

    public int CalculateTotalLoad()
    {
        var tilted = TiltNorth();
        var rows = tilted.Shape.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
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

    private static string Roll(string platformShape) =>
        Regex.Replace(platformShape, @"(\.)(.{11})(O)", "$3$2$1",
            RegexOptions.Compiled | RegexOptions.Singleline);
}