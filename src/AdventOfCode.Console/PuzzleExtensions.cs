public static class PuzzleExtensions {
    public static (int year, int day) GetPuzzleInfo<T>(this T puzzle)
    {
        var type = puzzle.GetType();
        var year = GetYear(type.Namespace!.Split('.')[^1]);
        var day = GetDay(type.Name[3..]);

        return (year, day);
    }

    private static int GetYear(string year) => year switch {
        "Fifteen" => 2015,
        "Sixteen" => 2016,
        "Seventeen" => 2017,
        "Eighteen" => 2018,
        "Nineteen" => 2019,
        "Twenty" => 2020,
        "TwentyOne" => 2021,
        "TwentyTwo" => 2022,
        "TwentyThree" => 2023,
        "TwentyFour" => 2024,
        _ => throw new InvalidOperationException($"Could not find puzzle type for year {year}"),
    };

    private static int GetDay(string day) => day switch {
        "One" => 1,
        "Two" => 2,
        "Three" => 3,
        "Four" => 4,
        "Five" => 5,
        "Six" => 6,
        "Seven" => 7,
        "Eight" => 8,
        "Nine" => 9,
        "Ten" => 10,
        "Eleven" => 11,
        "Twelve" => 12,
        "Thirteen" => 13,
        "Fourteen" => 14,
        "Fifteen" => 15,
        "Sixteen" => 16,
        "Seventeen" => 17,
        "Eighteen" => 18,
        "Nineteen" => 19,
        "Twenty" => 20,
        "TwentyOne" => 21,
        "TwentyTwo" => 22,
        "TwentyThree" => 23,
        "TwentyFour" => 24,
        "TwentyFive" => 25,
        _ => throw new InvalidOperationException($"Could not find puzzle type for day {day}"),
    };
}