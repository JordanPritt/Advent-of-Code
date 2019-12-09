using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day6
{
    public class OrbitCalculator
    {
        private Dictionary<string, string> orbits = new Dictionary<string, string>();

        public OrbitCalculator()
        {
            var orbitsList = from l in File.ReadAllLines("./orbits.txt")
                             select new { OuterPlanet = l.Split(")")[0], InnerPlanet = l.Split(")")[1] };

            foreach (var o in orbitsList)
            {
                orbits.Add(o.InnerPlanet, o.OuterPlanet);
            }
        }

        public void CalculateOrbits()
        {
            var count = orbits.Keys.Select(o => GetPath(o, orbits).Count).Sum();
            Console.WriteLine($"\norbits: {count}");

            List<string> you = GetPath("YOU", orbits);
            List<string> santa = GetPath("SAN", orbits);
            var intersects = you.Intersect(santa).First();
            var requiredTransfers = you.IndexOf(intersects) + santa.IndexOf(intersects);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"You");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" to ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"Santa: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{requiredTransfers}\n\n");
        }

        private List<String> GetPath(string planet, Dictionary<string, string> orbits)
        {
            List<string> path = new List<string>();
            string curPath = planet;

            while (curPath != "COM")
            {
                curPath = orbits[curPath];
                path.Add(curPath);
            }
            return path;
        }
    }
}