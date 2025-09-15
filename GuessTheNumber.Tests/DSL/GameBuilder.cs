using GuessTheNumber.Domain;
using Moq;

namespace GuessTheNumber.Tests.DSL;

public class GameBuilder
{
    private int _correctNumber = 1;

    public GameBuilder WithCorrectNumber(int correctNumber)
    {
        _correctNumber = correctNumber;
        return this;
    }

    public Game Please()
    {
        var mockNumberGenerator = new Mock<INumberGenerator>();
        mockNumberGenerator.Setup(gen =>
                gen.Generate())
            .Returns(_correctNumber);
        var settings = Create.Settings().Please();
        
        var game = new Game(mockNumberGenerator.Object, settings);
        
        return game;
    }
}