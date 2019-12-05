using System;
using System.Linq;
using System.Collections.Generic;

namespace Day5
{
    public class IntCode
    {
        public string Code { get; set; }
        //public int Input { get; set; }
        public int Opcode { get; private set; }
        public string Action { get; private set; }

        public IntCode(string code)
        {
            Code = code;
            Opcode = SetOpcode(code);
            Action = SetAction(int.Parse(code));
        }

        private int SetOpcode(string code)
        {
            return Convert.ToInt32(code[0].ToString());
        }
        private string SetAction(int input)
        {
            return input switch
            {
                1 => "ADD",
                2 => "MULTIPLY",
                // 3 => "",
                // 4 => "",
                99 => "EXIT",
                _ => throw new Exception("You done screwed up...")
            };
        }
    }
}