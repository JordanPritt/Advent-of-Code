using System;
using System.Linq;
using System.Collections.Generic;

namespace IntCode
{
    public class OpCode
    {
        public string Type { get; private set; }
        public OpCode(int code)
        {
            Type = code switch
            {
                1 => "Add",
                2 => "Multiply",
                3 => "Input",
                4 => "Output",
                99 => "Exit",
                _ => throw new ArgumentOutOfRangeException("Type", "OpCode's type is not appropriate.")
            };
        }
    }
}