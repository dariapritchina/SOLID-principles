namespace GuessTheNumber.Domain;

public class GameSettings(int maxAttempts, int minValue, int maxValue) : IGameSettings
{
    public int MaxAttempts { get; } = maxAttempts;
    public int MinValue { get; } = minValue;
    public int MaxValue { get; } = maxValue;
}