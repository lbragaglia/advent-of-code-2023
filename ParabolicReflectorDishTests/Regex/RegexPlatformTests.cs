namespace ParabolicReflectorDishTests.Regex;

[TestFixture]
public class RegexPlatformTests : AbstractPlatformTests
{
    protected override RegexPlatform GetSut() => new(InitialPlatformShape);

    [Test]
    public void TestFinalShape()
    {
        var platform = new RegexPlatform(InitialPlatformShape);
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

    [TestCase(".|.")]
    [TestCase("O|O")]
    [TestCase("#|#")]
    [TestCase(@"
.|O
O|.
")]
    [TestCase(@"
#|#
O|O
")]
    [TestCase(@"
O|O
#|#
")]
    [TestCase(@"
.#|O#
OO|.O
")]
    public void TestShapeBabySteps(string testData)
    {
        var initialShape = string.Join(Environment.NewLine, testData.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Split("|")[0]));
        var expectedFinalShape = string.Join(Environment.NewLine, testData.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Split("|")[1]));

        var platform = new RegexPlatform(initialShape);
        var actualShape = platform.TiltNorth().Shape;

        Assert.That(actualShape, Is.EqualTo(expectedFinalShape));
    }
}