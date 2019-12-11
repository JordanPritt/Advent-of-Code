using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day7
{
    public class IntcodeProcessor
    {
        private List<int> codesList = File.ReadAllText("./input-test.csv").Split(',').ToList().ConvertAll(int.Parse);
        private int position = 0;

        public int Phase { get; set; }
        public int Signal { get; set; }
        public int HaltCode { get; private set; }

        public IntcodeProcessor(int phase, int signal = 0)
        {
            Phase = phase;
            Signal = signal == 0 ? phase : signal;
        }

        public (int signal, int halt) RunProcess(int signal)
        {
            signal = signal == 0 ? Phase : signal;
            Signal = ProcessCode(Phase, signal);
            return (Signal, HaltCode);
        }

        private int ProcessCode(int phase, int signal)
        {
            int value1 = 0, value2 = 0;
            int signalOutput = signal;
            int input = phase;

            while (HaltCode != 99)
            {
                int op = codesList[position];
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
                    case 1: // add
                        value1 = value1Mode == 1 ? codesList[position + 1] : codesList[codesList[position + 1]];
                        value2 = value2Mode == 1 ? codesList[position + 2] : codesList[codesList[position + 2]];

                        if (param3Mode != 1)
                            codesList[codesList[position + 3]] = value1 + value2;
                        else
                            codesList[position + 3] = value1 + value2;
                        position += 4;
                        break;

                    case 2: // multiply
                        value1 = value1Mode == 1 ? codesList[position + 1] : codesList[codesList[position + 1]];
                        value2 = value2Mode == 1 ? codesList[position + 2] : codesList[codesList[position + 2]];

                        if (param3Mode != 1)
                            codesList[codesList[position + 3]] = value1 * value2;
                        else
                            codesList[position + 3] = value1 * value2;
                        position += 4;
                        break;

                    case 3: // input
                        if (value1Mode == 1)
                            codesList[position + 1] = input;
                        else
                            codesList[codesList[position + 1]] = input;
                        input = signal;
                        position += 2;
                        break;

                    case 4: // output
                        value1 = value1Mode == 1 ? codesList[position + 1] : codesList[codesList[position + 1]];
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("system output:");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write($" {value1}\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        signalOutput = value1;
                        position += 2; // store position to resume at
                        HaltCode = opcode;
                        return value1; // return current signal value

                    case 5: // jump if true
                        value1 = value1Mode == 1 ? codesList[position + 1] : codesList[codesList[position + 1]];
                        value2 = value2Mode == 1 ? codesList[position + 2] : codesList[codesList[position + 2]];

                        if (value1 != 0)
                            position = value2;
                        else
                            position += 3;
                        break;

                    case 6: // jump if false
                        value1 = value1Mode == 1 ? codesList[position + 1] : codesList[codesList[position + 1]];
                        value2 = value2Mode == 1 ? codesList[position + 2] : codesList[codesList[position + 2]];

                        if (value1 == 0)
                            position = value2;
                        else
                            position += 3;
                        break;

                    case 7: // less than
                        value1 = value1Mode == 1 ? codesList[position + 1] : codesList[codesList[position + 1]];
                        value2 = value2Mode == 1 ? codesList[position + 2] : codesList[codesList[position + 2]];

                        if (param3Mode == 1)
                            codesList[position + 3] = value1 < value2 ? 1 : 0;
                        else
                            codesList[codesList[position + 3]] = value1 < value2 ? 1 : 0;
                        position += 4;
                        break;

                    case 8: // equals
                        value1 = value1Mode == 1 ? codesList[position + 1] : codesList[codesList[position + 1]];
                        value2 = value2Mode == 1 ? codesList[position + 2] : codesList[codesList[position + 2]];

                        if (param3Mode == 1)
                            codesList[position + 3] = value1 == value2 ? 1 : 0;
                        else
                            codesList[codesList[position + 3]] = value1 == value2 ? 1 : 0;
                        position += 4;
                        break;

                    case 99: // exit
                        HaltCode = opcode;
                        return signalOutput;
                    default:
                        return signalOutput;
                }
            }
            return signalOutput;
        }
    }
}