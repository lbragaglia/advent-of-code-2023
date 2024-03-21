namespace ParabolicReflectorDishTests.Counting;

public class LinqCountingPlatform : IPlatform
{
    public string Shape { get; }

    public LinqCountingPlatform(string shape)
    {
        Shape = shape;
    }

    public int CalculateTotalLoad()
    {
        var rows = Shape.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        var startingLoad = rows.Length;
        var columns = rows[0].Length;
        return Enumerable
            .Range(0, columns)
            .Select(x => rows.Select((r, i) => (Char: r[x], RowLoad: startingLoad - i))
                .Aggregate(
                    (TotalLoad: 0, CurrentLoad: startingLoad),
                    (agg, curr) => curr.Char switch
                    {
                        IPlatform.RoundedRock => (agg.TotalLoad += agg.CurrentLoad, --agg.CurrentLoad),
                        IPlatform.CubeShapedRock => (agg.TotalLoad, curr.RowLoad - 1),
                        _ => agg
                    }))
            .Sum(x => x.TotalLoad);
    }
}