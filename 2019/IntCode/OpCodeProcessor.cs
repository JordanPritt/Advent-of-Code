using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace IntCode
{
    public class OpCodeProcessor
    {
        private List<int> codes = File.ReadAllText("./input.csv").Split(',').ToList().ConvertAll(int.Parse);
        public OpCode Code { get; set; }
        public OpCodeProcessor()
        {

        }

        public List<int> Execute()
        {
            int position = 0;

            while (true)
            {
                Code = new OpCode(codes[position]);
                if (Code.Type == "Exit")
                    break;

                List<int> parameters = new List<int>()
                {
                    codes[position + 1],
                    codes[position + 2],
                    codes[position + 3]
                };

                position += 4;

                ProcessCode(Code, parameters);
            }

            return codes;
        }

        public void ProcessCode(OpCode code, List<int> parameters)
        {
            int val1 = codes[parameters[0]];
            int val2 = codes[parameters[1]];
            int val3 = codes[parameters[2]];

            switch (code.Type)
            {
                case "Add":
                    codes[parameters[2]] = val1 + val2;
                    break;
                case "Multiply":
                    codes[parameters[2]] = val1 * val2;
                    break;
            }
        }
    }
}