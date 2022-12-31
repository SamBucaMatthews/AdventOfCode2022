namespace AdventOfCode2022.Tests.DayTenTests;

using AdventOfCode2022.Solutions.DayTen;

public class CpuTests
{
    private Cpu _cpu = null!;

    [SetUp]
    public void SetUp()
    {
        _cpu = new Cpu();
    }

    [Test]
    public void SignalStrength_GivenOnlyOneNoopCommand_CalculatesCorrectly()
    {
        _cpu.Noop();
        
        Assert.That(_cpu.SignalStrengths[2], Is.EqualTo(2));
    }
    
    [Test]
    public void SignalStrength_GivenMultipleNoopCommands_CalculatesCorrectly()
    {
        _cpu.Noop();
        _cpu.Noop();
        _cpu.Noop();
        
        Assert.That(_cpu.SignalStrengths[4], Is.EqualTo(4));
    }

    [TestCase(5)]
    [TestCase(-5)]
    public void SignalStrength_GivenOnlyOneAddCommand_CalculatesCorrectly(int change)
    {
        const int cycleToEndOn = 3;
        var expected = (change + 1) * cycleToEndOn;

        _cpu.AddX(change);
        
        Assert.That(_cpu.SignalStrengths[3], Is.EqualTo(expected));
    }
    
    [Test]
    public void SignalStrength_GivenMultipleAddCommands_CalculatesCorrectly()
    {
        _cpu.AddX(1);
        _cpu.AddX(1);
        _cpu.AddX(1);
        
        Assert.Multiple(() =>
        {
            Assert.That(_cpu.SignalStrengths[1], Is.EqualTo(1));
            Assert.That(_cpu.SignalStrengths[2], Is.EqualTo(2));
            Assert.That(_cpu.SignalStrengths[3], Is.EqualTo(6));
            Assert.That(_cpu.SignalStrengths[4], Is.EqualTo(8));
            Assert.That(_cpu.SignalStrengths[5], Is.EqualTo(15));
            Assert.That(_cpu.SignalStrengths[6], Is.EqualTo(18));
            Assert.That(_cpu.SignalStrengths[7], Is.EqualTo(28));
        });
    }
}
