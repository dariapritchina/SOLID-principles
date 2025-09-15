namespace GuessTheNumber.Tests.DSL;

public class Create
{
    public static SettingsBuilder Settings()
    {
        return new SettingsBuilder();
    }

    public static GameBuilder Game()
    {
        return new GameBuilder();
    }
}