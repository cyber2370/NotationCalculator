using System;

namespace NotationCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string binaryNumber1 = "100", binaryNumber2 = "10";

            var calc = new NotationCalculator(10, binaryNumber1, binaryNumber2);

            Console.WriteLine($"Get Sum: {binaryNumber1} + {binaryNumber2} = {calc.GetSum()}");
            Console.WriteLine();

            Console.WriteLine($"Get Multiply: {binaryNumber1} * {binaryNumber2} = {calc.GetMultiply()}");
            Console.WriteLine();

            Console.WriteLine($"Get Subtraction: {binaryNumber1} - {binaryNumber2} = {calc.GetSubtraction()}");
            Console.WriteLine();

            Console.WriteLine($"Get Division: {binaryNumber1} / {binaryNumber2} = {calc.GetDivision()}");
            Console.ReadKey();
        }
    }
}