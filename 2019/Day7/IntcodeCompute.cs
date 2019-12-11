using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day7
{
    public class IntcodeCompute
    {
        public int Phase { get; set; }
        public int Signal { get; private set; }
        public int HaltCode { get; private set; }

        public IntcodeCompute(int phase, int signal)
        {
            Phase = phase;
            Signal = signal;
        }

        public int Compute()
        {
            Signal = ProcessCode(Phase, Signal);
            return Signal;
        }

        private int ProcessCode(int phase, int signal)
        {
            List<int> codesList = File.ReadAllText("./input-test.csv").Split(',').ToList().ConvertAll(int.Parse);
            int value1 = 0, value2 = 0;
            int signalOutput = signal;
            int input = phase;

            for (int i = 0; i < codesList.Count;)
            {
                int op = codesList[i];
                int opcode = op % 100;
                int value1Mode = (op % 1000) / 100;
                int value2Mode = (op % 10000) / 1000;
                int param3Mode = op / 10000;

                if (opcode == 99)
                {
                    HaltCode = opcode;
                    return signalOutput;
                }

                switch (opcode)
                {
                    case (int)CodeAction.Add:
                        value1 = value1Mode == 1 ? codesList[i + 1] : codesList[codesList[i + 1]];
                        value2 = value2Mode == 1 ? codesList[i + 2] : codesList[codesList[i + 2]];

                        if (param3Mode != 1)
                            codesList[codesList[i + 3]] = value1 + value2;
                        else
                            codesList[i + 3] = value1 + value2;
                        i += 4;
                        break;

                    case (int)CodeAction.Multiply:
                        value1 = value1Mode == 1 ? codesList[i + 1] : codesList[codesList[i + 1]];
                        value2 = value2Mode == 1 ? codesList[i + 2] : codesList[codesList[i + 2]];

                        if (param3Mode != 1)
                            codesList[codesList[i + 3]] = value1 * value2;
                        else
                            codesList[i + 3] = value1 * value2;
                        i += 4;
                        break;

                    case (int)CodeAction.Input:
                        if (value1Mode == 1)
                            codesList[i + 1] = input;
                        else
                            codesList[codesList[i + 1]] = input;
                        input = signal;
                        i += 2;
                        break;

                    case (int)CodeAction.Output:
                        value1 = value1Mode == 1 ? codesList[i + 1] : codesList[codesList[i + 1]];
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("system output:");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write($" {value1}\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        signalOutput = value1;
                        i += 2;
                        break;

                    case (int)CodeAction.JumpIfTrue:
                        value1 = value1Mode == 1 ? codesList[i + 1] : codesList[codesList[i + 1]];
                        value2 = value2Mode == 1 ? codesList[i + 2] : codesList[codesList[i + 2]];

                        if (value1 != 0)
                            i = value2;
                        else
                            i += 3;
                        break;

                    case (int)CodeAction.JumpIfFalse:
                        value1 = value1Mode == 1 ? codesList[i + 1] : codesList[codesList[i + 1]];
                        value2 = value2Mode == 1 ? codesList[i + 2] : codesList[codesList[i + 2]];

                        if (value1 == 0)
                            i = value2;
                        else
                            i += 3;
                        break;

                    case (int)CodeAction.LessThan:
                        value1 = value1Mode == 1 ? codesList[i + 1] : codesList[codesList[i + 1]];
                        value2 = value2Mode == 1 ? codesList[i + 2] : codesList[codesList[i + 2]];

                        if (param3Mode == 1)
                            codesList[i + 3] = value1 < value2 ? 1 : 0;
                        else
                            codesList[codesList[i + 3]] = value1 < value2 ? 1 : 0;
                        i += 4;
                        break;

                    case (int)CodeAction.Equals:
                        value1 = value1Mode == 1 ? codesList[i + 1] : codesList[codesList[i + 1]];
                        value2 = value2Mode == 1 ? codesList[i + 2] : codesList[codesList[i + 2]];

                        if (param3Mode == 1)
                            codesList[i + 3] = value1 == value2 ? 1 : 0;
                        else
                            codesList[codesList[i + 3]] = value1 == value2 ? 1 : 0;
                        i += 4;
                        break;

                    case (int)CodeAction.Exit:
                        HaltCode = opcode;
                        return signalOutput;
                    default:
                        return signalOutput;
                }
            }
            return signalOutput;
        }
    }
    public enum CodeAction
    {
        Add = 1,
        Multiply = 2,
        Input = 3,
        Output = 4,
        JumpIfTrue = 5,
        JumpIfFalse = 6,
        LessThan = 7,
        Equals = 8,
        Exit = 99
    }
}