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
            string binaryNumber1 = "100.10", binaryNumber2 = "200.20";

            var calc = new NotationCalculator(10, binaryNumber1, binaryNumber2);

            //Console.WriteLine(calc.GetSum());

            Console.WriteLine();

            Console.WriteLine(calc.GetMultiply());

            Console.ReadKey();
        }
    }
}