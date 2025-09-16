using GuessTheNumber.Tests.DSL;

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
        var settings = Create.Settings().WithMixMax(10, 99).Please();
        var generator = new NumberGenerator(settings);
        
        var result = generator.Generate();
        
        Assert.That(result, Is.GreaterThanOrEqualTo(10));
    }

    [Test]
    public void ResultShouldBe_LessOrEqualThanMaximumSetting()
    {
        var settings = Create.Settings().WithMixMax(10, 99).Please();
        var generator = new NumberGenerator(settings);
        
        var result = generator.Generate();
        
        Assert.That(result, Is.LessThanOrEqualTo(99));
    }

    [Test]
    public void ForEqualMinAndMax_ResultShouldBeEqualToMinMax()
    {
        var settings = Create.Settings().WithMixMax(13, 13).Please();
        var generator = new NumberGenerator(settings);
        
        var result = generator.Generate();
        
        Assert.That(result, Is.EqualTo(13));
    }
}