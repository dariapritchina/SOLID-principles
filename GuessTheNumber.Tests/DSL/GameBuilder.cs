using GuessTheNumber.Domain;
using GuessTheNumber.Interfaces;
using Moq;

namespace GuessTheNumber.Tests.DSL;

public class GameBuilder
{
    private int _correctNumber = 1;
    private int _maxAttemps = 3;
    private IUserInterface _userInterface = new DummyUserInterface();

    public GameBuilder WithCorrectNumber(int correctNumber)
    {
        _correctNumber = correctNumber;
        return this;
    }
    
    public GameBuilder WithMaxAttempts(int maxAttempts)
    {
        _maxAttemps = maxAttempts;
        return this;
    }
    
    public GameBuilder WithUI(IUserInterface userInterface)
    {
        _userInterface = userInterface;
        return this;
    }

    public Game Please()
    {
        var mockNumberGenerator = new Mock<INumberGenerator>();
        mockNumberGenerator.Setup(gen =>
                gen.Generate())
            .Returns(_correctNumber);
        var settings = Create.Settings().WithMaxAttempts(_maxAttemps).Please();
        
        var game = new Game(mockNumberGenerator.Object, settings, _userInterface);
        
        return game;
    }
}