using AdventOfCode.Puzzles.TwentyThree;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPuzzlesForTwentyThree(this IServiceCollection services)
    {
        services.AddTransient<DayOne>();
        services.AddTransient<DayTwo>();
        services.AddTransient<DayThree>();
        services.AddTransient<DayFour>();
        services.AddTransient<DayFive>();
        services.AddTransient<DaySix>();
        services.AddTransient<DaySeven>();
        services.AddTransient<DayEight>();
        services.AddTransient<DayNine>();

        return services;
    }
}
