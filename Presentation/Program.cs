using System;
using Domain.Abstraction;
using Domain.Implementation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging; // Ensure this is included

class Program
{
    static void Main(string[] args)
    {
        // Set up dependency injection
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);

        // Build the service provider
        var serviceProvider = serviceCollection.BuildServiceProvider();

        // Get the calculator instance
        var calculator = serviceProvider.GetRequiredService<IScoreCalculator>();

        Console.WriteLine("Enter integers separated by commas (e.g., 1,2,3):");
        string input = Console.ReadLine();

        try
        {
            int[] numbers = Array.ConvertAll(input.Split(','), int.Parse);

            int totalScore = calculator.CalculateScore(numbers);

            Console.WriteLine("Total Score: " + totalScore);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter integers separated by commas.");
        }
    }

    private static void ConfigureServices(IServiceCollection services)
    {
       
        services.AddLogging(configure => configure.AddConsole());

       
        services.AddTransient<IScoreCalculator, ScoreCalculator>();
    }
}
