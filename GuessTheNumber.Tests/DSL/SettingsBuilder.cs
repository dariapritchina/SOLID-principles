using GuessTheNumber.Domain;

namespace GuessTheNumber.Tests.DSL;

public class SettingsBuilder
{
    private int _maxAttemps = 3;
    private int _minValue = 1;
    private int _maxValue = 99;
    
    public SettingsBuilder WithMaxAttempts(int maxAttempts)
    {
        _maxAttemps = maxAttempts;
        return this;
    }
    
    public SettingsBuilder WithMixMax(int minValue, int maxValue)
    {
        _minValue = minValue;
        _maxValue = maxValue;
        return this;
    }

    public IGameSettings Please()
    {
        var gameSettings = new GameSettings(_maxAttemps, _minValue, _maxValue);

        return gameSettings;
    }
}