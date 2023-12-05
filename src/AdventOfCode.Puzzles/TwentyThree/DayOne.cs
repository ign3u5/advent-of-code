using AdventOfCode.Common;

namespace AdventOfCode.Puzzles.TwentyThree;

public class DayOne : IPuzzle
{
    public object RunTaskOne(string[] lines)
    {
        int total = 0;
        foreach (var line in lines)
        {
            int firstDigit = 0, secondDigit = 0;
            for (var i = 0; i < line.Length; i++)
            {
                if (int.TryParse(line.AsSpan(i, 1), out firstDigit)) 
                {
                    break;
                }
            }

            for (var i = line.Length - 1; i >= 0; i--)
            {
                if (int.TryParse(line.AsSpan(i, 1), out secondDigit)) 
                {
                    break;
                }
            }

            total += firstDigit * 10 + secondDigit;
        }

        return total;
    }

    public object RunTaskTwo(string[] lines)
    {
                int total = 0;
        foreach (var line in lines)
        {
            int firstDigit = 0, secondDigit = 0;
            for (var i = 0; i < line.Length; i++)
            {
                if (int.TryParse(line.AsSpan(i, 1), out firstDigit)) 
                {
                    break;
                }

                if (TryTranslate(line.AsSpan(..(i+1)), out firstDigit)) 
                {
                    break;
                }
            }

            for (var i = line.Length - 1; i >= 0; i--)
            {
                if (int.TryParse(line.AsSpan(i, 1), out secondDigit)) 
                {
                    break;
                }

                if (TryTranslateEnd(line.AsSpan(i..), out secondDigit)) 
                {
                    break;
                }
            }

            total += firstDigit * 10 + secondDigit;
        }

        return total;
    }

    private bool TryTranslateEnd(ReadOnlySpan<char> input, out int output) {
        output = 0;

        if (input.Length < 3)
        {
            return false;
        }

        output = input[..3] switch
            {
                "one" => 1,
                "two" => 2,
                "six" => 6,
                _ => 0
            };

        if (output != 0) return true;
        
        if (input.Length < 4)
        {
            return false;
        }

        output = input[..4] switch
        {
            "four" => 4,
            "five" => 5,
            "nine" => 9,
            _ => 0
        };
        
        if (output != 0) return true;

        if (input.Length < 5)
        {
            return false;
        }

        output = input[..5] switch
        {
            "three" => 3,
            "seven" => 7,
            "eight" => 8,
            _ => 0
        };

        return output != 0;
    }

    private bool TryTranslate(ReadOnlySpan<char> input, out int output) {
        output = 0;

        if (input.Length < 3)
        {
            return false;
        }

        output = input[^3..] switch
            {
                "one" => 1,
                "two" => 2,
                "six" => 6,
                _ => 0
            };

        if (output != 0) return true;
        
        if (input.Length < 4)
        {
            return false;
        }

        output = input[^4..] switch
        {
            "four" => 4,
            "five" => 5,
            "nine" => 9,
            _ => 0
        };
        
        if (output != 0) return true;

        if (input.Length < 5)
        {
            return false;
        }

        output = input[^5..] switch
        {
            "three" => 3,
            "seven" => 7,
            "eight" => 8,
            _ => 0
        };

        return output != 0;
    }
}