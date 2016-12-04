using System;

namespace NotationCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Number num1 = new Number("100.2333", 8),
                num2 = new Number("A.11A5", 16);
            
            string sumOperation = $"{num1}(notation: {num1.Notation}) + {num2}(notation: {num2.Notation})";
            Console.WriteLine($"Get Sum: {sumOperation} = {MathExecutor.Execute(num1, num2, MathOperations.Addition)}\n\n");

            string substractOperation = $"{num1}(notation: {num1.Notation}) - {num2}(notation: {num2.Notation})";
            Console.WriteLine($"Get Substract: {substractOperation} = {MathExecutor.Execute(num1, num2, MathOperations.Subtraction)}\n\n");

            string multiplicationOperation = $"{num1}(notation: {num1.Notation}) * {num2}(notation: {num2.Notation})";
            Console.WriteLine($"Get Multiply: {multiplicationOperation} = {MathExecutor.Execute(num1, num2, MathOperations.Multiplication)}\n\n");

            string divideOperation = $"{num1}(notation: {num1.Notation}) / {num2}(notation: {num2.Notation})";
            Console.WriteLine($"Get Division: {divideOperation} = {MathExecutor.Execute(num1, num2, MathOperations.Division)}\n\n");

            Console.ReadLine();
        }
    }
}