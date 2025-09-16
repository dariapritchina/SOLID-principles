public class NumberGenerator(IGameSettings settings) : INumberGenerator
{
    private readonly int _minValue = settings.MinValue;
    private readonly int _maxValue = settings.MaxValue;

    private static readonly Random Random = new();

    public int Generate()
    {
        return Random.Next(_minValue, _maxValue);
    }
}