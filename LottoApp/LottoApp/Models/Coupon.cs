using System.Collections.Generic;


namespace LottoApp.Models
{
    public class Coupon
    {
        public string Name { get; }
        public Coupon(List<List<int>> Lines, string Name)
        {
            this.Lines = Lines;
            this.Name = Name;
        }
        public readonly List<List<int>> Lines;

        public List<KeyValuePair<int, int>> CompareWithAllLines(List<int> lineToCompare)
        {
            if (lineToCompare.Count != 7)
                return null;

            List<KeyValuePair<int, int>> NumberOfMatches = new List<KeyValuePair<int, int>>();
            int lineNumber = 0;

            foreach (var line in Lines)
            {
                int match = 0;
                foreach (var number in lineToCompare)
                {
                    if (line.Contains(number))
                    {
                        match++;
                    }
                }
                NumberOfMatches.Add(new KeyValuePair<int, int>(lineNumber, match));
                lineNumber++;
            }
            return NumberOfMatches;
        }
    }
}