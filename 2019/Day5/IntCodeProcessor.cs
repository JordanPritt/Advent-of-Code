using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day5
{
    public class IntCodeProcessor
    {
        public string InputFile { get; set; }

        public IntCodeProcessor(string inputFile = "")
        {
            InputFile = inputFile;
        }

        public List<int> ProcessCodes(List<int> codeList = null)
        {
            List<int> newList = codeList ?? InitializeCodes(InputFile);

            for (int i = 0; i < newList.Count; i++)
            {
                List<int> code = new List<int>();

                if (newList[i].ToString().Length == 4)
                    code.AddRange(newList.GetRange(i + 1, 3));

                // IntCode ic = new IntCode(newList[i]);

                // if (ic.Action == CodeAction.Exit)
                //     break;

                // if (ic.Action == CodeAction.Input)
                // {
                //     newList[newList[i + 1]] = ic.Opcode;
                //     ++i;
                //     continue;
                // }
                // else if (ic.Action == CodeAction.Output)
                // {
                //     Console.WriteLine($"program output: {newList[i + 1]}");
                //     ++i;
                //     continue;
                // }

                // int param1 = ic.Modes[0] == 0 ? newList[newList[ic.Modes[0]]] : ic.Modes[0];
                // int param2 = ic.Modes[1] == 0 ? newList[newList[ic.Modes[1]]] : ic.Modes[1];
                // int position = ic.Modes[2] == 0 ? newList[ic.Modes[2]] : ic.Modes[2];
                // int result = 0;

                // if (ic.Action == CodeAction.Add)
                //     result = param1 + param2;
                // else if (ic.Action == CodeAction.Multiply)
                //     result = param1 * param2;

                // newList[position] = result;
                // i = i + 2;

            }

            return newList;
        }

        private List<int> InitializeCodes(string filePath)
        {
            List<int> codes = File.ReadAllText(filePath).Split(',').ToList().ConvertAll(int.Parse);
            return codes;
        }
    }
}