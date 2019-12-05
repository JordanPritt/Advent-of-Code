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

                //var result = icp.ProcessCodes();
                var result2 = icp.GetNounAndVerb();

                Console.WriteLine($"\nResult: {result2[0]}");
                Console.WriteLine("\nApplication ended...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}