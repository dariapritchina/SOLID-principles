namespace GuessTheNumber.Domain;

public class Game(INumberGenerator generator)
{
    private readonly int _correctNumber = generator.Generate();

    public GameResult Guess(int number)
    {
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