using System;

namespace NotationCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string number1 = "10", number2 = "100";
            int notation = 16;
            
            string sumOperation = $"{number1} + {number2}";
            Console.WriteLine($"Get Sum: {sumOperation} = {MathExecutor.Execute(sumOperation, notation)}\n\n");

            string substractOperation = $"{number1} - {number2}";
            Console.WriteLine($"Get Substract: {substractOperation} = {MathExecutor.Execute(substractOperation, notation)}\n\n");

            string multiplicationOperation = $"{number1} * {number2}";
            Console.WriteLine($"Get Multiply: {multiplicationOperation} = {MathExecutor.Execute(multiplicationOperation, notation)}\n\n");

            string divideOperation = $"{number1} / {number2}";
            Console.WriteLine($"Get Division: {divideOperation} = {MathExecutor.Execute(divideOperation, notation)}\n\n");

            Console.ReadLine();
        }
    }
}