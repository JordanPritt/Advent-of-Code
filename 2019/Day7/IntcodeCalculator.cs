using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day7
{
    public class IntcodeCalculator
    {
        public IntcodeCalculator() { }

        public int FindLargestSignal()
        {
            Queue<IntcodeProcessor> amps = new Queue<IntcodeProcessor>();
            List<int> results = new List<int>();
            IEnumerable<string> signals = Enumerable.Range(55555, 99999)
                      .Select(x => x.ToString("00000"))
                      .Where(x => x.Contains("0"))
                      .Where(x => x.Contains("1"))
                      .Where(x => x.Contains("2"))
                      .Where(x => x.Contains("3"))
                      .Where(x => x.Contains("4"));

            signals = new List<string>() { "98765" }; // test input

            foreach (string signal in signals) // run against all permutations
            {
                List<int> phaseList = new List<int>(signal.ToCharArray().ToList().Select(c => int.Parse(c.ToString())));
                int lastSignal = 0;

                foreach (int phase in phaseList)
                {
                    amps.Enqueue(new IntcodeProcessor(phase));
                }

                while (amps.Count > 0)
                {
                    var current = amps.Dequeue();
                    var res = current.RunProcess(lastSignal);

                    lastSignal = res.signal;
                    results.Add(res.signal);

                    if (res.halt == 99)
                        continue;
                    else
                        amps.Enqueue(current);
                }
            }
            Console.WriteLine($"\nsignal count:   {results.Count}");
            Console.WriteLine($"Ran each phase: {results.Count / 5}");
            return results.Max();
        }
    }
}