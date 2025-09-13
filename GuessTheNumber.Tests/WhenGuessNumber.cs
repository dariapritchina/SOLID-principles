using GuessTheNumber.Domain;

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
        var mockNumberGenerator = new Mock<INumberGenerator>();
        mockNumberGenerator.Setup(gen =>
            gen.Generate())
            .Returns(17);
        var game = new Game(mockNumberGenerator.Object);

        var result = game.Guess(17);
        
        Assert.That(result, Is.EqualTo(GameResult.Win));
    }

    [Test]
    public void ForNumberLessThanCorrect_ReturnsYourNumberIsLess()
    {
        var mockNumberGenerator = new Mock<INumberGenerator>();
        mockNumberGenerator.Setup(gen =>
                gen.Generate())
            .Returns(100);
        var game = new Game(mockNumberGenerator.Object);

        var result = game.Guess(14);
        
        Assert.That(result, Is.EqualTo(GameResult.YourNumberIsLess));
    }
    
    [Test]
    public void ForNumberGreaterThanCorrect_ReturnsYourNumberIsGreater()
    {
        var mockNumberGenerator = new Mock<INumberGenerator>();
        mockNumberGenerator.Setup(gen =>
                gen.Generate())
            .Returns(1);
        var game = new Game(mockNumberGenerator.Object);

        var result = game.Guess(999);
        
        Assert.That(result, Is.EqualTo(GameResult.YourNumberIsGreater));
    }

    [Test]
    public void ForMaxAttemptsExceeded_ReturnsMaxAttemptsExceeded()
    {
        const int maxAttempts = 3;
        var mockNumberGenerator = new Mock<INumberGenerator>();
        mockNumberGenerator.Setup(gen =>
                gen.Generate())
            .Returns(1);
        var game = new Game(mockNumberGenerator.Object, maxAttempts);
        for (var i = 0; i < maxAttempts; i++)
        {
            game.Guess(999);
        }
        
        var result = game.Guess(999);

        Assert.That(result, Is.EqualTo(GameResult.MaxAttemptsExceeded));
    }
}