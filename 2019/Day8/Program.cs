using System;
using System.IO;

namespace Day8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Application starting...");

            int width = 25;
            int height = 6;

            TxtImg ti = new TxtImg();
            ti.FormatInput(width, height);
        }
    }
}
