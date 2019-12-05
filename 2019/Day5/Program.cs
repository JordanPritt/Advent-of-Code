using System;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string filePath = "./input-test.csv";
                IntCodeProcessor icp = new IntCodeProcessor(filePath);

                var result = icp.ProcessCodes();
                Console.WriteLine("\nApplication ended...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}