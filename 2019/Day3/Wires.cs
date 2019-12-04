using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day3
{
    public class Wires
    {
        private const string inputFilePath = "./input.txt";

        private List<string> WirePath1 { get; set; }
        private List<string> WirePath2 { get; set; }

        public Wires()
        {
            GetWires(inputFilePath);
        }

        public void Calculate()
        {
            var path1 = GetPoints(WirePath1);
            var path2 = GetPoints(WirePath2);
            var intersections = path1.Keys.Intersect(path2.Keys).ToArray();

            Console.WriteLine($"closest intersection: {intersections.Min(p => Math.Abs(p.x) + Math.Abs(p.y))}");
            Console.WriteLine($"distance: {intersections.Min(x => path1[x] + path2[x])}");

        }

        public Dictionary<(int x, int y), int> GetPoints(List<string> paths)
        {
            int x = 0, y = 0, pathDistance = 0;
            Dictionary<(int x, int y), int> pathDict = new Dictionary<(int x, int y), int>();

            foreach (var path in paths)
            {
                var direction = path[0];
                var distance = Convert.ToInt32(path[1..]);

                for (int i = 0; i < distance; i++)
                {
                    var newPoint = direction switch
                    {
                        'R' => (++x, y),
                        'D' => (x, --y),
                        'L' => (--x, y),
                        'U' => (x, ++y),
                        _ => throw new Exception("You done screwed up, input...")
                    };

                    pathDict.TryAdd(newPoint, ++pathDistance);
                }
            }

            return pathDict;
        }

        private void GetWires(string path)
        {
            var lines = File.ReadLines(path);
            foreach (var line in lines)
            {
                if (WirePath1 == null)
                    WirePath1 = line.Split(",").ToList();
                else
                    WirePath2 = line.Split(",").ToList();
            }
        }
    }
}