using GuessTheNumber.Domain;

var gameSettings = new GameSettings(5, minValue: 1, maxValue: 100);
var generator = new NumberGenerator(gameSettings);
var consoleUI = new ConsoleUserInterface();
var game = new Game(generator, gameSettings, consoleUI);

game.Play();