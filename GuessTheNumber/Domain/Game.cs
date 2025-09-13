namespace GuessTheNumber.Domain;

public class Game(INumberGenerator generator, IGameSettings settings)
{
    public int MaxAttempts { get; } = settings.MaxAttempts;
    public int CurrentAttempt { get; private set; } = 0;
    private readonly int _correctNumber = generator.Generate();
    
    public GameResult Guess(int number)
    {
        CurrentAttempt++;
        if (CurrentAttempt > MaxAttempts)
        {
            return GameResult.MaxAttemptsExceeded;
        }
        
        GameResult result;

        if (number == _correctNumber)
        {
            result = GameResult.Win;
        }
        else if (number < _correctNumber)
        {
            result = GameResult.YourNumberIsLess;
        }
        else if (number > _correctNumber)
        {
            result = GameResult.YourNumberIsGreater;
        }
        else
        {
            result = GameResult.Lose;
        }
        
        return result;
    }
}