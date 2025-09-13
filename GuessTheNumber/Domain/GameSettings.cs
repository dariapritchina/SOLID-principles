namespace GuessTheNumber.Domain;

public class GameSettings(int maxAttempts) : IGameSettings
{
    public int MaxAttempts { get; } = maxAttempts;
}