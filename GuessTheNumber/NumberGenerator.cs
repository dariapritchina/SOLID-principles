namespace GuessTheNumber.Tests;

public class NumberGenerator(int minValue, int maxValue) : INumberGenerator
{
    private static readonly Random Random = new();

    public int Generate()
    {
        return Random.Next(minValue, maxValue);
    }
}