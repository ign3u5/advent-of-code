﻿using AdventOfCode.Puzzles.TwentyThree;
using Microsoft.Extensions.DependencyInjection;
using Twenty = AdventOfCode.Puzzles.Twenty;
using TwentyFour = AdventOfCode.Puzzles.TwentyFour;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPuzzlesForTwenty(this IServiceCollection services)
    {
        services.AddTransient<Twenty.DayOne>();
        services.AddTransient<Twenty.DayTwo>();

        return services;
    }

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
        services.AddTransient<DayTen>();
        services.AddTransient<DayEleven>();
        services.AddTransient<DayTwelve>();

        return services;
    }

    public static IServiceCollection AddPuzzlesForTwentyFour(this IServiceCollection services)
    {
        services.AddTransient<TwentyFour.DayOne>();
        services.AddTransient<TwentyFour.DayTwo>();
        services.AddTransient<TwentyFour.DayThree>();
        services.AddTransient<TwentyFour.DayFour>();
        services.AddTransient<TwentyFour.DayFive>();
        services.AddTransient<TwentyFour.DaySix>();
        services.AddTransient<TwentyFour.DaySeven>();
        services.AddTransient<TwentyFour.DayEight>();

        return services;
    }
}
