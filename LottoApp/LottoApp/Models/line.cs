using System.Collections.Generic;

namespace LottoApp.Models
{
    public class Line
    {
        public Line(List<int> numbers)
        {
            Numbers = numbers;
        }

        public List<int> Numbers { get; set; }

        public int CompareTo(Line line)
        {
            var i = 0;
            foreach (var number in line.Numbers)
            {
                if (Numbers.Contains(number))
                {
                    i++;
                }
            }

            return i;
        }
    }
}