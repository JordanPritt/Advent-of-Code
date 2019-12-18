using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day8
{
    public class TxtImg
    {
        const int HEIGHT = 2;
        const int WIDTH = 2;

        public void FormatInput()
        {
            string input = File.ReadAllText("input.txt");
            List<List<string>> layers = GetLayers(input);

            var smallRow = GetLeastZeroes(layers);
            int result = GetOneTimesTwo(smallRow);

            Console.WriteLine($"Smallest Zero 1 X 2: {result}\not");
            PrintImage(layers);
        }

        private List<List<string>> GetLayers(string input)
        {
            List<List<string>> layers = new List<List<string>>();

            for (int i = 0; i < input.Length - WIDTH;)
            {
                List<string> rows = new List<string>();

                for (int j = 0; j < HEIGHT; j++)
                {
                    string layer = input.Substring(i, WIDTH);
                    rows.Add(layer);
                    i += WIDTH;
                }

                layers.Add(rows);
            }

            return layers;
        }

        private void PrintImage(List<List<string>> layers)
        {
            List<string> output = new List<string>();

            foreach (List<string> layer in layers)
            {
                string row = "";

                foreach (string str in layer)
                {

                }
            }
        }

        private List<string> GetLeastZeroes(List<List<string>> input)
        {
            List<string> smallest = null;
            int small = -1;

            foreach (List<string> layer in input)
            {
                var flattened = String.Join(String.Empty, layer);
                int zeroes = (from c in flattened where c.ToString() == "0" select c).Count();

                if (small == -1)
                    small = zeroes;
                else if (small > zeroes)
                    small = zeroes;

                if (small == zeroes)
                    smallest = layer;
            }

            return smallest;
        }

        private int GetOneTimesTwo(List<string> layer)
        {
            string flattened = String.Join(String.Empty, layer);
            int ones = (from c in flattened where c.ToString() == "1" select c).Count();
            int twos = (from c in flattened where c.ToString() == "2" select c).Count();
            return ones * twos;
        }
    }
}