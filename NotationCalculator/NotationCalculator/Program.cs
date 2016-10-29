using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotationCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string binaryNumber1 = "HH", binaryNumber2 = "GG";

            var calc = new NotationCalculator(36, binaryNumber1, binaryNumber2);

            var res = calc.GetSum();
        }
    }
}