using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day8
{
    public class TxtImg
    {
        const int HEIGHT = 6;
        const int WIDTH = 25;

        public void FormatInput()
        {
            string input = File.ReadAllText("input.txt");
            List<int[,]> layers = GetIntLayers(input);

            var smallRow = GetLeastZeroes(layers);
            int result = GetOneTimesTwo(smallRow);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Smallest Zero 1 X 2: ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write($"{result}\n");
            Console.ForegroundColor = ConsoleColor.White;
            PrintImage(layers);
        }

        private List<int[,]> GetIntLayers(string input)
        {
            List<int[,]> layers = new List<int[,]>();
            int width = 0, height = 0;
            int[,] currentLayer = new int[WIDTH, HEIGHT];

            foreach (var c in input)
            {
                if (width >= WIDTH)
                {
                    width = 0;
                    height++;
                    if (height >= HEIGHT)
                    {
                        layers.Add(currentLayer);
                        width = 0;
                        height = 0;
                        currentLayer = new int[WIDTH, HEIGHT];
                    }
                }
                currentLayer[width++, height] = int.Parse(c.ToString());
            }

            layers.Add(currentLayer);
            return layers;
        }

        private void PrintImage(List<int[,]> layers)
        {
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    var layer = 0;
                    while (layers[layer][j, i] == 2)
                    {
                        layer++;
                    }
                    if (layers[layer][j, i] == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("**");
                    }
                    else if (layers[layer][j, i] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("||");
                    }
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        private int[,] GetLeastZeroes(List<int[,]> input)
        {
            int[,] smallest = null;
            int small = -1;

            foreach (int[,] layer in input)
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

        private int GetOneTimesTwo(int[,] layer)
        {
            string flattened = String.Join(String.Empty, layer);
            int ones = (from c in flattened where c.ToString() == "1" select c).Count();
            int twos = (from c in flattened where c.ToString() == "2" select c).Count();
            return ones * twos;
        }
    }
}