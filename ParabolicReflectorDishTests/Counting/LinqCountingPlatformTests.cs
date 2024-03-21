namespace ParabolicReflectorDishTests.Counting;

[TestFixture]
public class LinqCountingPlatformTests : AbstractPlatformTests
{
    protected override LinqCountingPlatform GetSut() => new(InitialPlatformShape);
}