using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day1
{
    public class FuelCalculator
    {
        private const string dataFilePath = "./mass-inputs-for-day-1.txt";

        private List<int> Masses { get; set; }
        private List<int> RequiredFuel { get; set; }
        public int NeededFuelTotal { get; private set; }
        public int RequiredFuelTotal { get; private set; }

        public FuelCalculator()
        {
            Masses = new List<int>();
            RequiredFuel = new List<int>();

            ImportDataFromFile();

            NeededFuelTotal = CalculateAllFuelNeeds();
            RequiredFuelTotal = CalculateRequiredFuel();
        }

        private void ImportDataFromFile()
        {
            var data = File.ReadAllLines(dataFilePath);
            Masses.AddRange(data.Select(int.Parse).ToArray());
        }

        private int CalculateRequiredFuel()
        {
            int currentFuelNeeds = 0;

            foreach (int mass in Masses)
            {
                decimal current = Convert.ToDecimal(mass);

                while ((Math.Floor(current / 3) - 2) >= 0)
                {
                    current = (Math.Floor(current / 3) - 2);
                    currentFuelNeeds += decimal.ToInt32(current);
                }
            }

            return currentFuelNeeds;
        }

        private int CalculateAllFuelNeeds()
        {
            decimal total = 0;

            foreach (int mass in Masses)
            {
                total = total + (Math.Floor(Convert.ToDecimal(mass) / 3) - 2);
            }

            return decimal.ToInt32(total);
        }
    }
}