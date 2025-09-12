namespace GuessTheNumber.Domain;

public class Game(INumberGenerator generator)
{
    private readonly int _correctNumber = generator.Generate();

    public GameResult Guess(int number)
    {
        if (number == _correctNumber)
        {
            return GameResult.Win;
        }

        return GameResult.Lose;
    }
}