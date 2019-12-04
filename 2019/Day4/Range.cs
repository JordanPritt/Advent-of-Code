using System;
using System.Linq;
using System.Collections.Generic;

namespace Day4
{
    public class Range
    {
        public int StartRange { get; set; }
        public int EndRange { get; set; }

        public Range(int start, int end)
        {
            StartRange = start;
            EndRange = end;
        }

        public int CalculateNumberOfCombinations()
        {
            int count = 0;
            for (int i = StartRange; i < EndRange; i++)
            {
                if (IsValidNumber(i) == true)
                    count = count + 1;
            }

            return count;
        }

        private bool IsValidNumber(int num)
        {
            bool sameChar = HasSameAdjacentChar(num);
            bool correctLength = HasCorrectLength(num);
            bool hasLinear = HasLinearIncrease(num);

            if (sameChar == true && correctLength == true && hasLinear == true)
                return true;
            else
                return false;
        }

        private bool HasLinearIncrease(int num)
        {
            string number = num.ToString();
            int previousNum = Convert.ToInt32(number[0].ToString());
            bool valid = false;

            for (int i = 1; i < number.Length; i++)
            {
                if (Convert.ToInt32(number[i].ToString()) >= previousNum)
                    valid = true;
                else
                    return false;

                previousNum = Convert.ToInt32(number[i].ToString());
            }

            return valid;
        }

        private bool HasCorrectLength(int num)
        {
            string number = num.ToString();
            if (number.Length == 6)
                return true;
            else
                return false;
        }

        private bool HasSameAdjacentChar(int num)
        {
            var check = num.ToString().OrderBy(x => x);
            bool valid = Enumerable.SequenceEqual(num.ToString(), check);
            int repeats = check.GroupBy(x => x).Where(g => g.Count() == 2).Count();

            if (!valid)
                return false;
            else if (repeats > 0)
                return true;
            else
                return false;
        }
    }
}