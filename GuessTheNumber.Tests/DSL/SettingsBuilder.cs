using GuessTheNumber.Domain;

namespace GuessTheNumber.Tests.DSL;

public class SettingsBuilder
{
    private int _maxAttemps = 3;
    
    public SettingsBuilder WithMaxAttempts(int maxAttempts)
    {
        _maxAttemps = maxAttempts;
        return this;
    }

    public IGameSettings Please()
    {
        var gameSettings = new GameSettings(_maxAttemps);

        return gameSettings;
    }
}