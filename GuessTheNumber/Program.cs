using GuessTheNumber.Domain;

var game = CreateNewGame();

game.Play();

Game CreateNewGame()
{
    var gameSettings = new GameSettings(7, minValue: 1, maxValue: 100);
    var generator = new NumberGenerator(gameSettings);
    var consoleUI = new ConsoleUserInterface();
    var game = new Game(generator, gameSettings, consoleUI);
    
    return game;
}