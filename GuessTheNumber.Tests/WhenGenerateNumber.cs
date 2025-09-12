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
        const int maxValue = 100;
        var generator = new NumberGenerator(10, maxValue);
        
        var result = generator.Generate();
        
        Assert.That(result, Is.GreaterThanOrEqualTo(10));
    }

    [Test]
    public void ResultShouldBe_LessOrEqualThanMaximumSetting()
    {
        const int minValue = 99;
        var generator = new NumberGenerator(minValue, 100);
        
        var result = generator.Generate();
        
        Assert.That(result, Is.LessThanOrEqualTo(100));
    }

    [Test]
    public void ForEqualMinAndMax_ResultShouldBeEqualToMinMax()
    {
        const int minValue = 13;
        const int maxValue = 13;
        var generator = new NumberGenerator(minValue, maxValue);
        
        var result = generator.Generate();
        
        Assert.That(result, Is.EqualTo(13));
    }
}