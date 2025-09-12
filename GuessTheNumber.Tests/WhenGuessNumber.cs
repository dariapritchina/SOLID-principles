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
}