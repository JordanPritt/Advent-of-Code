using System;
using System.IO;
using System.Collections.Generic;

namespace Day2
{
    public class OpCode
    {
        private const string testPath = "./test-input.csv";
        private const string path = "./input.csv";
        private const int output = 19690720;

        public List<int> Codes { get; private set; }

        public OpCode()
        {
            Codes = LoadIntcodes();
        }
        public int GetNounAndVerb()
        {
            List<int> test = new List<int>();

            for (int noun = 0; noun <= 99; noun++)
            {
                for (int verb = 0; verb <= 99; verb++)
                {
                    test = LoadIntcodes();
                    test[1] = noun;
                    test[2] = verb;

                    for (int i = 0; i < Codes.Count; i += 4)
                    {
                        int currOpcode = Codes[i];

                        switch (currOpcode)
                        {
                            case 1:
                                test = AdjustCodeList(CodeAction.Add, i, test);
                                break;
                            case 2:
                                test = AdjustCodeList(CodeAction.Multiply, i, test);
                                break;
                            default:
                                break;
                        }
                    }

                    if (test[0] == 19690720)
                    {
                        Console.WriteLine($"\nnoun: {noun} verb: {verb}\n\nresult: {100 * noun + verb}");
                        return test[0];
                    }
                }
            }

            return test[0];
        }
        public List<int> CalculateNewList()
        {
            List<int> newCodes = new List<int>();
            newCodes = Codes;
            newCodes[1] = 12;
            newCodes[2] = 2;

            for (int i = 0; i < Codes.Count; i += 4)
            {
                int currOpcode = Codes[i];

                switch (currOpcode)
                {
                    case 1:
                        newCodes = AdjustCodeList(CodeAction.Add, i, newCodes);
                        break;
                    case 2:
                        newCodes = AdjustCodeList(CodeAction.Multiply, i, newCodes);
                        break;
                    default:
                        break;
                }
            }

            return newCodes;
        }

        ///  sets the int list according to changes ///
        private List<int> AdjustCodeList(CodeAction action, int index, List<int> codes)
        {
            int val1 = codes[codes[index + 1]];
            int val2 = codes[codes[index + 2]];
            int position = codes[index + 3];
            int result = 0;

            if (action == CodeAction.Add)
                result = val1 + val2;
            else if (action == CodeAction.Multiply)
                result = val1 * val2;

            codes[position] = result;

            return codes;
        }

        /// gets the list of ints ///
        private List<int> LoadIntcodes()
        {
            var lines = File.ReadAllText(path);
            string[] linesArray = lines.Split(',');
            List<int> codes = new List<int>();

            foreach (var line in linesArray)
            {
                codes.Add(Convert.ToInt32(line));
            }

            return codes;
        }
        private enum CodeAction
        {
            Add,
            Multiply
        }
    }
}