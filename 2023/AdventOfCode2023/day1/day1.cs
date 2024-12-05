using System.Linq;
using System.IO;
using System.Xml.XPath;
using Support;
using System.Data;
using System.Text.RegularExpressions;

namespace Execution
{
    public class Day1 : Exercise
    {
        const string datapath = "C:/Users/Marco/OneDrive/Desktop/Advent Of Code/AdventOfCode2023/day1/data.txt";
        private Test<string[], int[]> test1
        {
            get
            {
                return new Test<string[], int[]>()
                {
                    input = ["1abc2", "pqr3stu8vwx", "a1b2c3d4e5f", "treb7uchet"],
                    expected = [12, 38, 15, 77]
                };
            }
        }
        private Test<string[], int[]> test2
        {
            get
            {
                return new Test<string[], int[]>()
                {
                    input = ["two1nine", "eightwothree", "abcone2threexyz", "xtwone3four", "4nineeightseven2", "zoneight234", "7pqrstsixteen"],
                    expected = [29, 83, 13, 24, 42, 14, 76]
                };
            }
        }
        public Day1() : base() { }
        public override void Part1(bool test = false)
        {
            var data = test ? test1.input : File.ReadAllLines(datapath);
            Console.WriteLine("Advent Of Code - Executing day1, part1...");

            var output = 0;
            var numbers = from item in data select int.Parse(ReadCoordinates(item));
            if (test) Console.Write("numbers: ");
            foreach (int n in numbers)
            {
                if (test) Console.Write(n + ", ");
                output += n;
            }

            Console.WriteLine($"Result = {output}");
        }
        public override void Part2(bool test = false)
        {
            var data = test ? test2.input : File.ReadAllLines(datapath);

            Console.WriteLine("Advent Of Code - Executing day1, part2...");

            var output = 0;
            var numbers = from item in data select int.Parse(ReadCoordinatesLiteral(item));
            if (test) Console.Write("numbers: ");
            foreach (int n in numbers)
            {
                if (test) Console.Write(n + ", ");
                output += n;
            }

            Console.WriteLine($"Result = {output}");
        }
        private string ReadCoordinates(string item)
        {
            var matches = Regex.Matches(item, @"\d");
            return matches.First().Value + matches.Last().Value;
        }
        private string ReadCoordinatesLiteral(string item)
        {
            var matches = Regex.Matches(item, @"\d|one|two|three|four|five|six|seven|eight|nine|ten|eleven|twelve|thirteen|fourteen|fiveteen|sixteen
|seventeen|eighteen|nineteen|twenty|thirty|fourty|fifty|sixty|seventy|eighty|ninety", RegexOptions.IgnoreCase);
            return convertLiteralNumbers(matches.First().Value) + convertLiteralNumbers(matches.Last().Value);
        }
        private string convertLiteralNumbers(string value)
        {

            Dictionary<string, int> simplest = new Dictionary<string, int>(){
                { "one", 1 },
                { "two", 2 },
                { "three", 3 },
                { "four", 4 },
                { "five", 5 },
                { "six", 6 },
                { "seven", 7 },
                { "eight", 8 },
                { "nine", 9 },
                { "ten", 10 },
                { "eleven", 11 },
                { "twelve", 12 },
                { "thirteen", 13 },
                { "fourteen", 14 },
                { "fiveteen", 15 },
                { "sixteen", 16 },
                { "seventeen", 17 },
                { "eighteen", 18 },
                { "ninenteen", 19 },
                { "twenty", 20 },
                { "thirty", 30},
                { "fourty", 40},
                { "fifty", 50},
                { "sixty", 60},
                { "seventy", 70},
                { "eighty", 80},
                { "ninety", 90}
            };
            // Dictionary<string, int> ones = new Dictionary<string, int>(){
            //     { "one", 1 },
            //     { "two", 2 },
            //     { "three", 3 },
            //     { "four", 4 },
            //     { "five", 5 },
            //     { "six", 6 },
            //     { "seven", 7 },
            //     { "eight", 8 },
            //     { "nine", 9 }
            // };
            // Dictionary<string, int> teens = new Dictionary<string, int>()
            // {
            //     { "ten", 10 },
            //     { "eleven", 11 },
            //     { "twelve", 12 },
            //     { "therteen", 13 },
            //     { "fourteen", 14 },
            //     { "fiveteen", 15 },
            //     { "sixteen", 16 },
            //     { "seventeen", 17 },
            //     { "eighteen", 18 },
            //     { "ninenteen", 19 },
            // };
            // Dictionary<string, int> tens = new Dictionary<string, int>()
            // {
            //     { "twenty", 20 },
            //     { "thirty", 30},
            //     { "fourty", 40},
            //     { "fivety", 50},
            //     { "sixty", 60},
            //     { "seventy", 70},
            //     { "eighty", 80},
            //     { "ninety", 90}
            // };
            // Dictionary<string, int> thousandsGroups = new Dictionary<string, int>()
            // {
            //     { "hundred" , 100},
            //     { "thousand", 1000},
            //     { "million", 1000000},
            //     { "billion", 1000000000}
            // };
            return simplest.ContainsKey(value) ? simplest[value].ToString() : value;
        }

    }
}