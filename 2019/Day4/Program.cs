using System;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            Range r = new Range(356261, 846303);
            int result = r.CalculateNumberOfCombinations();

            Console.WriteLine($"Number of combinations: {result}");
        }
    }
}
