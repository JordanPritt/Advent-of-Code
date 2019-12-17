using System;

namespace Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Processing signals...\n");
                IntcodeCalculator ip = new IntcodeCalculator();
                int result = ip.FindLargestSignal();

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("\nComputed signal:");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($" {result}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(ex);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
