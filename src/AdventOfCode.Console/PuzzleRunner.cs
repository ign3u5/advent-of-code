using AdventOfCode.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;

public interface IPuzzleRunner : IDisposable
{
    Task Run<T>() where T : IPuzzle;
}

public class PuzzleRunner : IPuzzleRunner
{
    private readonly IPuzzleRetrievalService _puzzleRetrievalService;
    private readonly IServiceProvider _serviceProvider;

    public PuzzleRunner(IPuzzleRetrievalService puzzleRetrievalService, IServiceProvider serviceProvider)
    {
        _puzzleRetrievalService = puzzleRetrievalService;
        _serviceProvider = serviceProvider;
    }

    public async Task Run<T>() where T : IPuzzle
    {
        var puzzle = _serviceProvider.GetRequiredService<T>();
        var (year, day) = puzzle.GetPuzzleInfo();
        var inputLines = await _puzzleRetrievalService.GetInputLines(year, day);
        
        Console.WriteLine($"Task one: {puzzle.RunTaskOne(inputLines)}");
        Console.WriteLine($"Task two: {puzzle.RunTaskTwo(inputLines)}");
    }

    public void Dispose()
    {
        _puzzleRetrievalService.Dispose();
    }
}