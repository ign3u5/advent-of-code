// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, World!");

IConfigurationRoot configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile("secrets.json", optional: true, reloadOnChange: true)
    .Build();

var assetOptions = configuration.GetSection(AssetsOptions.SectionName).Get<AssetsOptions>()!;

ServiceCollection serviceCollection = new();

serviceCollection.AddSingleton(assetOptions);

serviceCollection.AddPuzzlesForTwentyThree();

serviceCollection.AddTransient<IPuzzleRunner, PuzzleRunner>();

serviceCollection.AddHttpClient<IPuzzleRetrievalService, PuzzleRetrievalService>(client =>
{
    client.DefaultRequestHeaders.Add("Cookie", $"session={assetOptions.Session}");
});

IServiceProvider service = serviceCollection.BuildServiceProvider();

using IPuzzleRunner puzzleRunner = service.GetRequiredService<IPuzzleRunner>();

await puzzleRunner.Run<AdventOfCode.Puzzles.TwentyThree.DayEleven>();