namespace ParabolicReflectorDishTests;

public abstract class AbstractPlatformTests
{
    protected string InitialPlatformShape = null!;

    [SetUp]
    public void Setup()
    {
        InitialPlatformShape = @"
O....#....
O.OO#....#
.....##...
OO.#O....O
.O.....O#.
O.#..O.#.#
..O..#O..O
.......O..
#....###..
#OO..#....
";
    }

    [Test]
    public void TestLoad()
    {
        var platform = GetSut();
        var actualLoad = platform.CalculateTotalLoad();
        const int expectedLoad = 136;

        Assert.That(actualLoad, Is.EqualTo(expectedLoad));
    }

    protected abstract IPlatform GetSut();
}