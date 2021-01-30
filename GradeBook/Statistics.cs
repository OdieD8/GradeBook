using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook
{
    public class Statistics
    {
        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }

        public double High;
        public double Low;
        public char Letter
        {
            get
            {
                if (Average >= 90.0)
                {
                    return 'A';
                }
                else if (Average >= 80.0)
                {
                    return 'B';
                }
                else if (Average >= 70.0)
                {
                    return 'C';
                }
                else if (Average >= 60.0)
                {
                    return 'D';
                }
                else
                {
                    return 'F';
                }
            }
            
        }
        public double Sum;
        public int Count;

        public void Add(double number)
        {
            Sum += number;
            Count += 1;
            Low = Math.Min(number, Low);
            High = Math.Max(number, High);
        }

        public Statistics()
        {
            Count = 0;
            High = double.MinValue;
            Low = double.MaxValue;
            Sum = 0.0;
        }

       
    }
}
