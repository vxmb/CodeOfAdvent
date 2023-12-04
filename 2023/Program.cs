using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _2023
{
    class Program
    {
        static void Main(string[] args)
        {
            const string textFile = "./input.csv";
            var lines = File.ReadAllLines(textFile);

            Console.WriteLine($"Amount of lines: {lines.Length}");

            var pattern = @"[0-9]+|(one)|(two)|(three)|(four)|(five)|(six)|(seven)|(eight)|(nine)";

            var sum = lines
                .Select(l => {
                        Console.WriteLine($"Before: {l}");

                        var matches = Regex.Matches(l, pattern, RegexOptions.IgnorePatternWhitespace);
                        Console.WriteLine("Found {0} matches.", matches.Count);

                        var split = new List<string>();
                        foreach (Match match in matches)
                            split.Add(match.Groups[0].Value);

                        Console.WriteLine($"Split concated: {string.Concat(split)}");

                        var convertedValues = split.Select(s => s switch 
                                {
                                    "one" => "1",
                                    "two" => "2",
                                    "three" => "3",
                                    "four" => "4",
                                    "five" => "5",
                                    "six" => "6",
                                    "seven" => "7",
                                    "eight" => "8",
                                    "nine" => "9",
                                    var x => x
                                });
                        Console.WriteLine($"All values concated: {string.Concat(convertedValues)}");
                        var allDigits = string.Concat(convertedValues);
                        var firstDigit = allDigits[0];
                        var secondDigit = allDigits[^1];

                        var number = $"{firstDigit}{secondDigit}";
                        Console.WriteLine($"After: {number}");
                        return int.Parse(number);
                        })
                .Sum();

            Console.WriteLine($"The answer is {sum}.");
        }
    }
}
