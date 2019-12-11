using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day7
{
    public class IntcodeProcessor
    {
        public IntcodeProcessor() { }

        public int FindLargestSignal()
        {
            List<int> results = new List<int>();

            // var signals = Enumerable.Range(0, 44444)
            var signals = Enumerable.Range(55555, 99999)
                      .Select(x => x.ToString("00000"))
                      .Where(x => x.Contains("0"))
                      .Where(x => x.Contains("1"))
                      .Where(x => x.Contains("2"))
                      .Where(x => x.Contains("3"))
                      .Where(x => x.Contains("4"));

            List<string> test = new List<string>() { "98765" };

            foreach (string signal in test)
            {
                List<int> signalAsList = new List<int>();
                foreach (char c in signal)
                {
                    int i = Convert.ToInt32(c.ToString());
                    signalAsList.Add(i);
                }

                results.Add(FindThrusterSignal(signalAsList));
            }

            return results.Max();
        }

        private int FindThrusterSignal(List<int> phaseSequence)
        {
            int outputSignal = 0;
            phaseSequence.ForEach(i => outputSignal = new IntcodeCompute(i, outputSignal).Compute());

            return outputSignal;
        }
    }
}