using GuessTheNumber.Interfaces;

namespace GuessTheNumber.Domain;

public class ConsoleUserInterface : IUserInterface
{
    public int AskNumber()
    {
        while (true)
        {
            Console.Write($"Guess your number: ");
            if (int.TryParse(Console.ReadLine(), out var answer))
            {
                return answer;
            }

            Console.WriteLine("Please guess the integer number.");
        }

    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}