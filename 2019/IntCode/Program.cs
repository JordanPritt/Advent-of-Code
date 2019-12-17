using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace IntCode
{
    class Program
    {
        static void Main(string[] args)
        {
            OpCodeProcessor processor = new OpCodeProcessor();
            var result = processor.Execute();
            Console.WriteLine($"Result: {result[0]}");
        }
    }
}
