using System.Numerics;

public static class Maths {

    /// <summary>
    /// Finds the highest common factor of two numbers.
    /// </summary>
    /// <remarks>
    /// If <paramref name="a"/> is 15 and <paramref name="b"/> is 10, the highest common factor they can both be divided by is 5.
    /// </remarks>
    public static T HighestCommonFactor<T>(T a, T b) where T : INumber<T> {
        T remainder = a % b;

        return remainder == T.Zero ? b : HighestCommonFactor(b, remainder);
    }

    /// <summary>
    /// Finds the lowest common multiple of two numbers.
    /// </summary>
    /// <remarks>
    /// If <paramref name="a"/> is 15 and <paramref name="b"/> is 10, the lowest common multiple is 30.
    /// <br/>10, 20, 30
    /// <br/>15, 30
    /// </remarks>
    public static T LowestCommonMultiple<T>(T a, T b) where T : INumber<T> {
        return a * b / HighestCommonFactor(a, b);
    }
}