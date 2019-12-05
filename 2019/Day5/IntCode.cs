using System;
using System.Linq;
using System.Collections.Generic;

namespace Day5
{
    public class IntCode
    {
        public CodeAction Action { get; private set; }
        public List<int> Modes { get; private set; }
        public int Opcode { get; private set; }

        public IntCode(int code)
        {
            string codeString = code.ToString();
            Opcode = Convert.ToInt32(codeString.Last().ToString());
            Action = Opcode switch
            {
                1 => CodeAction.Add,
                2 => CodeAction.Multiply,
                3 => CodeAction.Input,
                4 => CodeAction.Output,
                99 => CodeAction.Exit,
                _ => throw new Exception("You done screwed up the CodeAction...")
            };

            List<int> modes = new List<int>();
            string m = codeString.Remove(codeString.Length - 2);

            for (int i = 0; i < 3; i++)
            {
                if (m.Length > i)
                    modes.Add(Convert.ToInt32(m[i].ToString()));
                else
                    modes.Add(0);
            }

            modes.Reverse();
            Modes = modes;
        }
    }
}