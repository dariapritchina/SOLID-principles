namespace GuessTheNumber.Tests;

public class WhenGenerateNumber
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ResultShouldBe_GreaterOrEqualThanMinimumSetting()
    {
        const int minValue = 10;
        var generator = new NumberGenerator(minValue);
        
        var result = generator.Generate();
        
        Assert.That(result, Is.GreaterThanOrEqualTo(minValue));
    }
}