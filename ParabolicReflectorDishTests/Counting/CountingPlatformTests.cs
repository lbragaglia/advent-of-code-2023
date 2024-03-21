namespace ParabolicReflectorDishTests.Counting;

[TestFixture]
public class CountingPlatformTests : AbstractPlatformTests
{
    protected override CountingPlatform GetSut() => new(InitialPlatformShape);
}