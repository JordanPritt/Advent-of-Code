using System;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                OpCode oc = new OpCode();

                #region Part 1
                var res = oc.CalculateNewList();
                foreach (var code in res)
                {
                    Console.Write($"{code}, ");
                }
                #endregion

                #region Part 2
                var test = oc.GetNounAndVerb();

                Console.WriteLine($"\n\nresult: {test}");
                #endregion

                Console.WriteLine("\nApplication ended...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}