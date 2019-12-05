using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day5
{
    public class IntCodeProcessor
    {
        public string InputFile { get; set; }
        public List<int> Codes { get; private set; }


        public IntCodeProcessor(string inputFile = "")
        {
            InputFile = inputFile;
            Codes = InitializeCodes(inputFile) ?? new List<int>();
        }
        /// <summary>
        /// Processes the int code application.
        /// </summary>
        public List<int> ProcessCodes(List<int> codeList = null)
        {
            List<int> newList = codeList ?? InitializeCodes(InputFile);
            CodeAction currAct;

            for (int i = 0; i < newList.Count; i += 4)
            {
                int opcode = newList[i];

                currAct = opcode switch
                {
                    1 => CodeAction.Add,
                    2 => CodeAction.Multiply,
                    99 => CodeAction.Exit,
                    _ => throw new Exception("You done screwed up...")
                };

                if (currAct == CodeAction.Exit)
                    break;

                int param1 = newList[newList[i + 1]];
                int param2 = newList[newList[i + 2]];
                int position = newList[i + 3];
                int result = 0;

                if (currAct == CodeAction.Add)
                    result = param1 + param2;
                else if (currAct == CodeAction.Multiply)
                    result = param1 * param2;

                newList[position] = result;
            }

            return newList;
        }

        public List<int> GetNounAndVerb()
        {
            List<int> newList = new List<int>();

            for (int noun = 0; noun <= 99; noun++)
            {
                for (int verb = 0; verb <= 99; verb++)
                {
                    newList = InitializeCodes(InputFile);
                    newList[1] = noun;
                    newList[2] = verb;

                    newList = ProcessCodes(newList);

                    if (newList[0] == 19690720)
                    {
                        Console.WriteLine($"\nnoun: {noun} verb: {verb}\n\nresult: {100 * noun + verb}");
                        return newList;
                    }
                }
            }

            return newList;
        }

        /// <summary>
        /// Initializes the list of int codes.
        /// </summary>
        /// <param name="filePath">String of the input file to get codes from.</param>
        /// <returns>A List<int> of int codes tp process.</returns>
        private List<int> InitializeCodes(string filePath)
        {
            List<int> codes = File.ReadAllText(filePath).Split(',').ToList().ConvertAll(int.Parse);
            return codes;
        }

        /// <summary>
        /// An enum of the possible actions to take for a given int code.
        /// </summary>
        private enum CodeAction
        {
            Add,
            Multiply,
            Exit
        }
    }
}