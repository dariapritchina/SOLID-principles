using GuessTheNumber.Interfaces;

namespace GuessTheNumber.Domain;

public class Game(INumberGenerator generator, IGameSettings settings, IUserInterface userInterface)
{
    public IUserInterface UserInterface { get; } = userInterface;
    private int MaxAttempts { get; } = settings.MaxAttempts;
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
        PrintWelcomeMessage();

        GameResult gameResult;
        do
        {
            var number = UserInterface.AskNumber();
            gameResult = Guess(number);
            PrintMessage(gameResult);
        }
        while (!EndOfTheGame(gameResult));
    }

    private bool EndOfTheGame(GameResult gameResult)
    {
        return gameResult is (GameResult.MaxAttemptsExceeded or GameResult.Win);
    }

    private void PrintWelcomeMessage()
    {
        var message = $"Welcome to the Guess of the Number game! " +
                      $"You have {MaxAttempts} attempts to guess the number. Let's play!";
        UserInterface.ShowMessage(message);
    }
    
    private void PrintMessage(GameResult gameResult)
    {
        var message = "";
        
        switch (gameResult)
        {
            case GameResult.YourNumberIsGreater:
                message = $"Your number is greater than {_correctNumber}";
                break;
            case GameResult.YourNumberIsLess:
                message = $"Your number is less than {_correctNumber}";
                break;
            case GameResult.MaxAttemptsExceeded:
                message = $"Max Attempts exceeded: {MaxAttempts}";
                break;
            case GameResult.Win:
                message = $"You win!";
                break;
        }
        
        UserInterface.ShowMessage(message);
    }
}