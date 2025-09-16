using GuessTheNumber.Interfaces;

namespace GuessTheNumber.Domain;

public class Game(INumberGenerator generator, IGameSettings settings, IUserInterface userInterface)
{
    public IUserInterface UserInterface { get; } = userInterface;
    public int MaxAttempts { get; } = settings.MaxAttempts;
    private int CurrentAttempt { get; set; } = 0;
    private readonly int _correctNumber = generator.Generate();
    
    public GameResult Guess(int number)
    {
        CurrentAttempt++;
        var result = CurrentAttempt > MaxAttempts ? 
            GameResult.MaxAttemptsExceeded : 
            CheckNumber(number);
        
        return result;
    }

    private GameResult CheckNumber(int number)
    {
        GameResult result;
        
        if (number < _correctNumber)
        {
            result = GameResult.YourNumberIsLess;
        }
        else if (number > _correctNumber)
        {
            result = GameResult.YourNumberIsGreater;
        }
        else // (number == _correctNumber)
        {
            result = GameResult.Win;
        }
        
        return result;
    }

    public void Play()
    {
        var number = UserInterface.AskNumber();
        Guess(number);
    }
}