using System;

namespace Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Processing signals...");
                IntcodeProcessor ip = new IntcodeProcessor();
                int result = ip.FindThrusterSignal();

                Console.Write("Computed signal:");
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
