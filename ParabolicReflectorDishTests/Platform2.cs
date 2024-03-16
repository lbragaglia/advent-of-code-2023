namespace ParabolicReflectorDishTests;

public class Platform2 : IPlatform
{
    public string Shape { get; }

    public Platform2(string shape)
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
            var roundedRocks = 0;
            for (var row = 0; row < rows.Length; row++)
            {
                switch (rows[row][col])
                {
                    case IPlatform.EmptySpace:
                        continue;
                    case IPlatform.RoundedRock:
                        roundedRocks++;
                        break;
                    case IPlatform.CubeShapedRock:
                        totalLoad += GetCurrentAreaLoad(roundedRocks, currentLoad);
                        roundedRocks = 0;
                        currentLoad = rows.Length - row - 1;
                        break;
                }
            }
            totalLoad += GetCurrentAreaLoad(roundedRocks, currentLoad);
        }

        return totalLoad;
    }

    private static int GetCurrentAreaLoad(int roundedRocks, int startingLoad)
    {
        var totalLoad = 0;
        while (roundedRocks > 0)
        {
            totalLoad += startingLoad;
            roundedRocks--;
            startingLoad--;
        }
        return totalLoad;
    }
}