using GuessTheNumber.Interfaces;
using GuessTheNumber.Tests.DSL;
using Moq;

namespace GuessTheNumber.Tests;

public class WhenPlayGame
{
    [Test]
    public void UserInterface_ShouldAskNumberAtLeastOnce()
    {
        // Arrange
        var mockUI = new Mock<IUserInterface>();
        var game = Create.Game().WithUI(mockUI.Object).Please();

        // Act
        game.Play();

        // Assert
        mockUI.Verify(ui => ui.AskNumber(), Times.AtLeastOnce);
    }
}