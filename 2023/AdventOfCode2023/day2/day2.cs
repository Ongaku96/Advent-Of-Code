using Support;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace Execution
{
    public class Day2 : Exercise
    {
        const string datapath = "C:/Users/Marco/OneDrive/Desktop/Advent Of Code/AdventOfCode2023/day2/data.txt";
        private Test<string, int> test1
        {
            get
            {
                return new Test<string, int>()
                {
                    input = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green\n" +
                            "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue\n" +
                            "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red\n" +
                            "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red\n" +
                            "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green",
                    expected = 8
                };
            }
        }
        public Day2() : base() { }

        public override void Part1(bool test = false)
        {
            var data = test ? test1.input.Split('\n') : File.ReadAllLines(datapath);
            Console.WriteLine($"day 2: {ReadData(data).Sum()}");
        }

        public override void Part2(bool test = false)
        {
            throw new NotImplementedException();
        }


        public static List<int> ReadData(string[] data)
        {
            return (from e in from g in data
                              select new
                              {
                                  id = Regex.Match(g.Split(':')[0], @"\d").Value,
                                  matches =
                  (from match in Regex.Matches(g, @"\d+ (red|blue|green)")
                   group match by Regex.Match(match.Value, @"red|blue|green").Value into round
                   select new { color = round.Key, values = (from r in round.ToArray() select int.Parse(Regex.Match(r.Value, @"\d+").Value)).ToArray() }).ToArray()
                              }
                    where (
                        from c in e.matches
                        where
                            //red
                            c.color == "red" && c.values.ToList().Exists((v) => v >= 12) ||
                            //green
                            c.color == "green" && c.values.ToList().Exists((v) => v >= 13) ||
                            //blue
                            c.color == "blue" && c.values.ToList().Exists((v) => v >= 14)
                        select c.color
                        ).Count() == 0
                    select int.Parse(e.id)).ToList();
        }
    }
}