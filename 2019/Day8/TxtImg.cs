using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day8
{
    public class TxtImg
    {
        const int HEIGHT = 3;
        const int WIDTH = 26;

        public void FormatInput(int height, int width)
        {
            string input = File.ReadAllText("input.txt");
            List<string> rows = GetRows(input);

            var smallRow = 0;
        }

        private List<string> GetRows(string input)
        {
            List<string> rows = new List<string>();

            for (int i = 0; i < input.Length - WIDTH;)
            {
                string row = input.Substring(i, WIDTH);
                rows.Add(row);
                i += WIDTH;
            }

            return rows;
        }
    }
}