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
        var generator = new NumberGenerator(minValue: 10, maxValue: 99);
        
        var result = generator.Generate();
        
        Assert.That(result, Is.GreaterThanOrEqualTo(10));
    }

    [Test]
    public void ResultShouldBe_LessOrEqualThanMaximumSetting()
    {
        var generator = new NumberGenerator(minValue: 10, maxValue: 99);
        
        var result = generator.Generate();
        
        Assert.That(result, Is.LessThanOrEqualTo(99));
    }

    [Test]
    public void ForEqualMinAndMax_ResultShouldBeEqualToMinMax()
    {
        var generator = new NumberGenerator(minValue:13, maxValue:13);
        
        var result = generator.Generate();
        
        Assert.That(result, Is.EqualTo(13));
    }
}