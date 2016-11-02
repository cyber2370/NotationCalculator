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
            string binaryNumber1 = "FF", binaryNumber2 = "CC";

            var calc = new NotationCalculator(16, binaryNumber1, binaryNumber2);

            Console.WriteLine($"Get Sum: {binaryNumber1} + {binaryNumber2} = {calc.GetSum()}");
            Console.WriteLine();

            Console.WriteLine($"Get Multiply: {binaryNumber1} * {binaryNumber2} = {calc.GetMultiply()}");
            Console.WriteLine();

            Console.WriteLine($"Get Subtraction: {binaryNumber1} - {binaryNumber2} = {calc.GetSubtraction()}");
            Console.ReadKey();
        }
    }
}