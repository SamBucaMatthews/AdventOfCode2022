using AdventOfCode2022.Solutions;

namespace AdventOfCode2022.Tests;

public class Tests
{
    private const string Input = """
            1000 
            2000 
            3000 
            
            4000  
             
            5000 
            6000   
        
            7000 
            8000 
            9000 
            
            10000  
         """;
    
    [Test]
    public void TotalCaloriesCarriedByElfWithMost_GivenInputsFromExample_SolvesCorrectly()
    {
        const int expected = 24000;
        var actual = DayOne.TotalCaloriesCarriedByElfWithMost(Input.Split(Environment.NewLine));

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TotalCaloriesCarriedByTopThreeElves_GivenInputsFromExample_SolvesCorrectly()
    {
        const int expected = 45000;
        var actual = DayOne.TotalCaloriesCarriedByTopThreeElves(Input.Split(Environment.NewLine));

        Assert.That(actual, Is.EqualTo(expected));
    }
}