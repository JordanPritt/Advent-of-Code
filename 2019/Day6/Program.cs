using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            StartPrompt();

            OrbitCalculator oc = new OrbitCalculator();
            oc.CalculateOrbits();

            // Part 2
            // var mypath = GetPathToCOM("YOU", orbits);
            // var santapath = GetPathToCOM("SAN", orbits);
            // var common = mypath.Intersect(santapath).First();
            // var result = mypath.IndexOf(common) + santapath.IndexOf(common);
            // Console.WriteLine($"[Part 2] Number of transfers = {result}");

            EndPrompt();
        }

        private static void StartPrompt()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Getting orbits:");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void EndPrompt()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Application end...");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
