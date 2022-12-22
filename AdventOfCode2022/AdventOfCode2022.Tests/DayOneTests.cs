using AdventOfCode2022.Solutions;

namespace AdventOfCode2022.Tests;

public class Tests
{
    [Test]
    public void Solve_GivenInputsFromExample_SolvesCorrectly()
    {
        const string input = """
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

        var actual = DayOne.Solve(input.Split(Environment.NewLine));
        const int expected = 24000;

        Assert.That(actual, Is.EqualTo(expected));
    }
}