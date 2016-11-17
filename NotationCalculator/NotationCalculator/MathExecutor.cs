using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NotationCalculator
{
    internal class Number
    {
        private string _value;

        public Number(string value, int notation)
        {
            Notation = notation;
            Value = value;
        }

        public string Value
        {
            get { return _value; }
            set
            {
                IsNegative = value.Contains('-');

                _value = value.Replace("-", "").TrimStart(' ', '0');
            }
        }

        public bool IsNegative { get; private set; }

        public int Notation { get; set; }
    }

    internal enum MathOperations
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

    public class MathExecutor
    {
        private static string _operation;
        private static int _notation;

        public MathExecutor(string operation, int notation)
        {
            _operation = operation.Trim(' ');
            _notation = notation;
        }

        public static string Execute(string operation, int notation)
        {
            _operation = operation;
            _notation = notation;

            Number num1, num2;
            MathOperations mathOperation;
            string splitString;

            if (_operation.IndexOf(" * ") != -1)
            {
                mathOperation = MathOperations.Multiplication;
                splitString = " * ";
            }
            else if (_operation.IndexOf(" / ") != -1)
            {
                mathOperation = MathOperations.Division;
                splitString = " / ";
            }
            else if (_operation.IndexOf(" + ") != -1)
            {
                mathOperation = MathOperations.Addition;
                splitString = " + ";
            }
            else if (_operation.IndexOf(" - ") != -1)
            {
                mathOperation = MathOperations.Subtraction;
                splitString = " - ";
            }
            else
            {
                return "Can not resolve operation.\n\n";
            }

            int index = _operation.IndexOf(splitString);
            var oper = _operation.Replace(splitString, "");

            num1 = new Number(oper.Substring(0, index).TrimStart(), _notation);
            num2 = new Number(oper.Substring(index).TrimStart(), _notation);

            return ResolveOperation(num1, num2, mathOperation);
        }

        private static string ResolveOperation(Number num1, Number num2, MathOperations mathOperation)
        {
            switch (mathOperation)
            {
                case MathOperations.Addition:
                {
                    return GetAddition(num1, num2);
                }
                case MathOperations.Subtraction:
                {
                    return GetSubtraction(num1, num2);
                }
                case MathOperations.Multiplication:
                {
                    return GetMultiplication(num1, num2);
                }
                case MathOperations.Division:
                {
                    return GetDivision(num1, num2);
                }

                default:
                {
                    return "Can not resolve operation!\n";
                }
            }
        }
        private static string GetAddition(Number num1, Number num2)
        {
            var notationCalculator = new NotationCalculator(_notation, num1.Value, num2.Value);
            string prefix = "";
            int comparingResult = notationCalculator.Compare(num1.Value, num2.Value);

            if (num1.IsNegative && num2.IsNegative)
            {
                prefix = "-";
            }
            else if (num1.IsNegative && !num2.IsNegative)
            {
                if (comparingResult > -1)
                {
                    notationCalculator = new NotationCalculator(_notation, num2.Value, num1.Value);
                    return notationCalculator.GetSubtraction();
                }

                notationCalculator = new NotationCalculator(_notation, num1.Value, num2.Value);
                return "-" + notationCalculator.GetSubtraction();
            }
            else if (!num1.IsNegative && num2.IsNegative)
            {
                if (comparingResult < 1)
                {
                    notationCalculator = new NotationCalculator(_notation, num1.Value, num2.Value);
                    return notationCalculator.GetSubtraction();
                }

                notationCalculator = new NotationCalculator(_notation, num2.Value, num1.Value);
                return "-" + notationCalculator.GetSubtraction();
            }
            
            return prefix + notationCalculator.GetSum();
        }

        private static string GetSubtraction(Number num1, Number num2)
        {
            var notationCalculator = new NotationCalculator(_notation, num1.Value, num2.Value);
            string prefix = "";
            int comparingResult = notationCalculator.Compare(num1.Value, num2.Value);

            if (!num1.IsNegative && !num2.IsNegative && comparingResult == 1)
            {
                prefix = "-";
                notationCalculator = new NotationCalculator(_notation, num2.Value, num1.Value);
            }
            else if (num1.IsNegative ^ num2.IsNegative)
            {
                if (num1.IsNegative)
                {
                    prefix = "-";
                }

                notationCalculator = new NotationCalculator(_notation, num1.Value, num2.Value);
                return prefix + notationCalculator.GetSum();
            }
            else if (num1.IsNegative && num2.IsNegative)
            {
                if (comparingResult > -1)
                {
                    notationCalculator = new NotationCalculator(_notation, num2.Value, num1.Value);
                    return notationCalculator.GetSubtraction();
                }

                notationCalculator = new NotationCalculator(_notation, num1.Value, num2.Value);
                return "-" + notationCalculator.GetSubtraction();
            }

            return prefix + notationCalculator.GetSubtraction();
        }

        private static string GetMultiplication(Number num1, Number num2)
        {
            string prefix = "";

            if (num1.IsNegative ^ num2.IsNegative)
            {
                prefix = "-";
            }

            var notationCalculator = new NotationCalculator(_notation, num1.Value, num2.Value);
            return prefix + notationCalculator.GetMultiply();
        }

        private static string GetDivision(Number num1, Number num2)
        {
            string prefix = "";

            if (num1.IsNegative ^ num2.IsNegative)
            {
                prefix = "-";
            }

            var notationCalculator = new NotationCalculator(_notation, num1.Value, num2.Value);
            return prefix + notationCalculator.GetDivision();
        }

        private static int Compare(Number num1, Number num2)
        {
            if (num1.IsNegative && !num2.IsNegative)
            {
                return -1;
            }
            if (!num1.IsNegative && num2.IsNegative)
            {
                return 1;
            }

            var notationCalc = new NotationCalculator(num1.Notation, num1.Value, num2.Value);
            int resultOfComparingValues = notationCalc.Compare(num1.Value, num2.Value);

            if (num1.IsNegative && num2.IsNegative)
            {
                if (resultOfComparingValues == 0)
                {
                    return resultOfComparingValues;
                }

                return resultOfComparingValues != -1 ? -1 : 1;
            }

            return resultOfComparingValues;
        }
    }
}
