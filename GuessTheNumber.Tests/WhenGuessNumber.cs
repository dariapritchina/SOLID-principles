using GuessTheNumber.Domain;
using GuessTheNumber.Tests.DSL;

namespace GuessTheNumber.Tests;
using Moq;

public class WhenGuessNumber
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ForTheCorrectNumber_ReturnsWin()
    {
        var game = Create.Game().WithCorrectNumber(17).Please();

        var result = game.Guess(17);
        
        Assert.That(result, Is.EqualTo(GameResult.Win));
    }

    [Test]
    public void ForNumberLessThanCorrect_ReturnsYourNumberIsLess()
    {
        var game = Create.Game().WithCorrectNumber(100).Please();

        var result = game.Guess(14);
        
        Assert.That(result, Is.EqualTo(GameResult.YourNumberIsLess));
    }
    
    [Test]
    public void ForNumberGreaterThanCorrect_ReturnsYourNumberIsGreater()
    {
        var game = Create.Game().WithCorrectNumber(1).Please();

        var result = game.Guess(999);
        
        Assert.That(result, Is.EqualTo(GameResult.YourNumberIsGreater));
    }

    [Test]
    public void ForMaxAttemptsExceeded_ReturnsMaxAttemptsExceeded()
    {
        const int maxAttempts = 3;
        var game = Create.Game()
            .WithCorrectNumber(1)
            .WithMaxAttempts(maxAttempts).Please();
        for (var i = 0; i < maxAttempts; i++)
        {
            game.Guess(999);
        }
        
        // one more time after maxAttempts
        var result = game.Guess(999);

        Assert.That(result, Is.EqualTo(GameResult.MaxAttemptsExceeded));
    }
}