using AdventOfCode.Common;
using FluentAssertions;

namespace AdventOfCode.Puzzles.Tests;

public abstract class BaseTests<T> where T : IPuzzle, new()
{
    public void TaskOne(string input, object expected) => 
        GenericTaskTest(input, expected, (sut, lines) => sut.RunTaskOne(lines));
    
    public void TaskTwo(string input, object expected) => 
        GenericTaskTest(input, expected, (sut, lines) => sut.RunTaskTwo(lines));

    private void GenericTaskTest(string input, object expected, Func<IPuzzle, string[], object> act)
    {
        // Arrange
        string[] lines = input.Split(Environment.NewLine);
        T sut = new();

        // Act
        object actualValue = act(sut, lines);

        // Assert
        actualValue.Should().Be(expected);
    }
}