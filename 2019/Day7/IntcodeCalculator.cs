using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day7
{
    public class IntcodeProcessor
    {
        public IntcodeProcessor() { }

        public int FindThrusterSignal()
        {
            List<int> phaseSequence = new List<int>() { 4, 3, 2, 1, 0 };
            int outputSignal = 0;

            ProcessCodes(4, 0);
            // foreach (int p in phaseSequence)
            // {
            //     Console.WriteLine($"Phase number: {p}");
            //     ProcessCodes(p, outputSignal);
            // }

            return outputSignal;
        }

        public int ProcessCodes(int phase, int signal)
        {
            List<int> codesList = File.ReadAllText("./input-test.csv").Split(',').ToList().ConvertAll(int.Parse);
            int signalOutput = signal;
            int input = phase;

            for (int i = 0; i < codesList.Count;)
            {
                int op = codesList[i];
                int opcode = op % 100;
                int value1Mode = (op % 1000) / 100;
                int value2Mode = (op % 10000) / 1000;
                int param3Mode = op / 10000;
                // int value1 = 0;
                // int value2 = 0;

                if (opcode == 99)
                    return signalOutput;

                // if (codesList.Count > i + 1)
                //     value1 = value1Mode == 1 ? codesList[i + 1] : codesList[codesList[i + 1]];

                // if (opcode < 3 && codesList.Count > i + 2)
                //     value2 = value2Mode == 1 ? codesList[i + 2] : codesList[codesList[i + 2]];

                // if (opcode != (int)CodeAction.Exit && codesList.Count > i + 1)
                //     value1 = value1Mode == 1 ? codesList[i + 1] : codesList[codesList[i + 1]];

                // if (opcode != (int)CodeAction.Exit
                //     && opcode != (int)CodeAction.Input
                //     && opcode != (int)CodeAction.Output
                //     && codesList.Count > i + 2)
                //     value2 = value2Mode == 1 ? codesList[i + 2] : codesList[codesList[i + 2]];

                switch (opcode)
                {
                    case (int)CodeAction.Add:
                        int value1 = value1Mode == 1 ? codesList[i + 1] : codesList[codesList[i + 1]];
                        int value2 = value2Mode == 1 ? codesList[i + 2] : codesList[codesList[i + 2]];

                        if (param3Mode != 1)
                            codesList[codesList[i + 3]] = value1 + value2;
                        else
                            codesList[i + 3] = value1 + value2;
                        i += 4;
                        break;

                    case (int)CodeAction.Multiply:
                        int value1 = value1Mode == 1 ? codesList[i + 1] : codesList[codesList[i + 1]];
                        int value2 = value2Mode == 1 ? codesList[i + 2] : codesList[codesList[i + 2]];

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
                        input = 0;
                        i += 2;
                        break;

                    case (int)CodeAction.Output:
                        int value = value1Mode == 1 ? codesList[i + 1] : codesList[codesList[i + 1]];
                        Console.WriteLine($"system: {value}");
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
                        return -1;
                    default:
                        return -1;
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
    public enum CodeMode
    {
        Position,
        Immediate,
        NotSet
    }
}