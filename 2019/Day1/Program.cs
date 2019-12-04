using System;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            FuelCalculator fc = new FuelCalculator();

            Console.WriteLine($"Needed Fuel amount: {fc.NeededFuelTotal}");
            Console.WriteLine($"Required Fuel amount: {fc.RequiredFuelTotal}");
        }
    }
}
