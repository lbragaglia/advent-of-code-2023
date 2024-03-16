namespace ParabolicReflectorDishTests;

[TestFixture]
public class PlatformTests : AbstractPlatformTests
{
    [Test]
    public void TestFinalShape()
    {
        var platform = new Platform(InitialPlatformShape);
        var actualShape = platform.TiltNorth().Shape;
        const string expectedShape = @"
OOOO.#.O..
OO..#....#
OO..O##..O
O..#.OO...
........#.
..#....#.#
..O..#.O.O
..O.......
#....###..
#....#....
";

        Assert.That(actualShape, Is.EqualTo(expectedShape));
    }

    protected override Platform GetSut() => new(InitialPlatformShape);
}