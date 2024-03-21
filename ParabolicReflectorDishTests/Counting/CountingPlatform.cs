namespace ParabolicReflectorDishTests.Counting;

public class CountingPlatform : IPlatform
{
    public string Shape { get; }

    public CountingPlatform(string shape)
    {
        Shape = shape;
    }

    public int CalculateTotalLoad()
    {
        var totalLoad = 0;
        var rows = Shape.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        var columns = rows[0].Length;
        for (var col = 0; col < columns; col++)
        {
            var currentLoad = rows.Length;
            for (var row = 0; row < rows.Length; row++)
            {
                switch (rows[row][col])
                {
                    case IPlatform.RoundedRock:
                        totalLoad += currentLoad;
                        currentLoad--;
                        break;
                    case IPlatform.CubeShapedRock:
                        currentLoad = rows.Length - row - 1;
                        break;
                }
            }
        }

        return totalLoad;
    }
}