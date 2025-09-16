using GuessTheNumber.Interfaces;

namespace GuessTheNumber.Domain;

public class DummyUserInterface : IUserInterface
{
    public int AskNumber()
    {
        return 0;
    }

    public void ShowMessage(string message)
    {
    }
}