using GuessTheNumber.Domain;

var gameSettings = new GameSettings(5);
var generator = new NumberGenerator(1, 100);
var consoleUI = new ConsoleUserInterface();
var game = new Game(generator, gameSettings, consoleUI);

game.Play();