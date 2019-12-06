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
            int index = 0;

            for (int i = 0; i < newList.Count; i += 2)
            {
                int opcode = 0;
                int opcodeMode = 0;
                int param1 = 0;
                int param1Mode;
                int param2 = 0;
                int param2Mode = 0;
                int position = 0;
                int code = newList[i];
                int codeSize = code.ToString().Length;

                if (code == 99)
                    break;

                if (codeSize == 4)
                {
                    opcode = Convert.ToInt32(code.ToString().Last().ToString());
                    opcodeMode = Convert.ToInt32(code.ToString()[codeSize - 2].ToString());
                    param1 = Convert.ToInt32(newList[index + 1].ToString());
                    param2 = Convert.ToInt32(newList[index + 2].ToString());
                    param1Mode = param1 = Convert.ToInt32(code.ToString()[codeSize - 3].ToString());
                    param2Mode = param1 = Convert.ToInt32(code.ToString()[codeSize - 4].ToString());
                }
                else
                {
                    opcode = code;
                    param1 = newList[index + 1];
                }
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