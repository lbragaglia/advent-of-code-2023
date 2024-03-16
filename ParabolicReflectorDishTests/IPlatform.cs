namespace ParabolicReflectorDishTests;

public interface IPlatform
{
    const char RoundedRock = 'O';
    const char CubeShapedRock = '#';
    const char EmptySpace = '.';

    int CalculateTotalLoad();
}