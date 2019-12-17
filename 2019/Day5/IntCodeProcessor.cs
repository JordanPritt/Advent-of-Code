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

            for (int i = 0; i < newList.Count;)
            {
                int op = newList[i];
                int opcode = op % 100;
                int value1Mode = (op % 1000) / 100;
                int value2Mode = (op % 10000) / 1000;
                int param3Mode = op / 10000;
                int value1 = 0;
                int value2 = 0;
                int input = 5;//1;

                if (opcode == 99)
                    return newList;

                if (newList.Count > i + 1)
                    value1 = value1Mode == 1 ? newList[i + 1] : newList[newList[i + 1]];

                if (opcode < 3 && newList.Count > i + 2)
                    value2 = value2Mode == 1 ? newList[i + 2] : newList[newList[i + 2]];

                if (opcode != (int)CodeAction.Exit && newList.Count > i + 1)
                    value1 = value1Mode == 1 ? newList[i + 1] : newList[newList[i + 1]];

                if (opcode != (int)CodeAction.Exit
                    && opcode != (int)CodeAction.Input
                    && opcode != (int)CodeAction.Output
                    && newList.Count > i + 2)
                    value2 = value2Mode == 1 ? newList[i + 2] : newList[newList[i + 2]];

                switch (opcode)
                {
                    case (int)CodeAction.Add:
                        if (param3Mode != 1)
                            newList[newList[i + 3]] = value1 + value2;
                        else
                            newList[i + 3] = value1 + value2;
                        i += 4;
                        break;

                    case (int)CodeAction.Multiply:
                        if (param3Mode != 1)
                            newList[newList[i + 3]] = value1 * value2;
                        else
                            newList[i + 3] = value1 * value2;
                        i += 4;
                        break;

                    case (int)CodeAction.Input:
                        if (value1Mode == 1)
                            newList[i + 1] = input;
                        else
                            newList[newList[i + 1]] = input;
                        i += 2;
                        break;

                    case (int)CodeAction.Output:
                        Console.WriteLine($"system: {value1}");
                        i += 2;
                        break;

                    case (int)CodeAction.JumpIfTrue:
                        if (value1 != 0)
                            i = value2;
                        else
                            i += 3;
                        break;

                    case (int)CodeAction.JumpIfFalse:
                        if (value1 == 0)
                            i = value2;
                        else
                            i += 3;
                        break;

                    case (int)CodeAction.LessThan:
                        if (param3Mode == 1)
                            newList[i + 3] = value1 < value2 ? 1 : 0;
                        else
                            newList[newList[i + 3]] = value1 < value2 ? 1 : 0;
                        i += 4;
                        break;

                    case (int)CodeAction.Equals:
                        if (param3Mode == 1)
                            newList[i + 3] = value1 == value2 ? 1 : 0;
                        else
                            newList[newList[i + 3]] = value1 == value2 ? 1 : 0;
                        i += 4;
                        break;

                    case (int)CodeAction.Exit:
                        return newList;

                    default:
                        break;
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