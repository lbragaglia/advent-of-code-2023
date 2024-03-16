namespace ParabolicReflectorDishTests;

[TestFixture]
public class Platform2Tests : AbstractPlatformTests
{
    protected override Platform2 GetSut() => new(InitialPlatformShape);
}