using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace NotationCalculator
{
    public class NotationCalculator
    {
        private readonly int _notation;

        private string _firstDigit;
        private string _secondDigit;

        public NotationCalculator(int notation, string firstDigit, string secondDigit)
        {
            _notation = notation;
            _firstDigit = firstDigit.Replace(",", ".");
            _secondDigit = secondDigit.Replace(",", ".");

            SetupDigits();
        }

        public string GetSum()
        {
            StringBuilder result = new StringBuilder(_firstDigit.Replace(".", ""));
            string secondDigit = _secondDigit.Replace(".", "");

            int digitsAfterFloatingPoint = GetDigitsAfterFloatingPoint();

            char flagA = ' ';

            for (int i = secondDigit.Length - 1; i >= 0; i--)
            {
                int currentValueFromResult = GetDecimalFromChar(result[i]),
                    currentValueFromSecondNumber = GetDecimalFromChar(secondDigit[i]),
                    nextDigitValue = 0;

                int tmpResult = currentValueFromSecondNumber + currentValueFromResult + nextDigitValue;

                if (tmpResult /_notation >= 1)
                {
                    nextDigitValue = Convert.ToInt32(Math.Floor((double) tmpResult / _notation));
                    tmpResult = tmpResult%_notation;
                }

                result[i] = GetCharFromDecimal(tmpResult);

                if (i != 0)
                {
                    result[i - 1] = GetCharSum(result[i - 1], GetCharFromDecimal(nextDigitValue));
                }
                else
                {
                    flagA = GetCharFromDecimal(nextDigitValue);
                }
            }

            result.Insert(result.Length - digitsAfterFloatingPoint, ".");

            return flagA + result.ToString();
        }

        private void SetupDigits()
        {
            SetupLengthOfNumbers();
            
            SetupFloatingPoint();
        }

        private void SetupLengthOfNumbers()
        {
            string realPartOfFirst = _firstDigit.Split('.')[0];
            string realPartOfSecond = _secondDigit.Split('.')[0];

            int difference = realPartOfFirst.Length - realPartOfSecond.Length;

            if (difference == 0)
                return;

            if (difference > 0)
            {
                for (int i = 0; i < difference; i++)
                    _secondDigit = "0" + _secondDigit;
            }
            else
            {
                for (int i = 0; i < -difference; i++)
                    _firstDigit = "0" + _firstDigit;
            }
        }

        private void SetupFloatingPoint()
        {
            string[] splittedFirstNumber = _firstDigit.Split('.');
            string[] splittedSecondNumber = _secondDigit.Split('.');

            if (splittedFirstNumber.Length > 1 && splittedSecondNumber.Length > 1)
            {
                string firstNumberFloatPart = splittedFirstNumber[1];
                string secondNumberFloatPart = splittedSecondNumber[1];

                if (firstNumberFloatPart.Length > secondNumberFloatPart.Length)
                {
                    for (int i = 0, diff = firstNumberFloatPart.Length - secondNumberFloatPart.Length;
                        i < diff; i++)
                    {
                        _secondDigit += "0";
                    }
                }
                else
                {
                    for (int i = 0, diff = secondNumberFloatPart.Length - firstNumberFloatPart.Length;
                        i < diff; i++)
                    {
                        _firstDigit += "0";
                    }
                }
            }
            else if (splittedFirstNumber.Length > 1)
            {
                _secondDigit += ".";

                for (int i = 0, length = splittedFirstNumber[1].Length; i < length; i++)
                {
                    _secondDigit += "0";
                }
            }
            else if (splittedSecondNumber.Length > 1)
            {
                _firstDigit += ".";

                for (int i = 0, length = splittedSecondNumber[1].Length; i < length; i++)
                {
                    _firstDigit += "0";
                }
            }
        }

        private int GetDigitsAfterFloatingPoint()
        {
            int numberOfDigitsAfterFloatingPoint1 = 0, 
                numberOfDigitsAfterFloatingPoint2 = 0;

            if (_firstDigit.Contains("."))
            {
                numberOfDigitsAfterFloatingPoint1 = _firstDigit.Split('.')[1].Length;
            }

            if (_secondDigit.Contains("."))
            {
                numberOfDigitsAfterFloatingPoint2 = _secondDigit.Split('.')[1].Length;
            }

            return numberOfDigitsAfterFloatingPoint1 > numberOfDigitsAfterFloatingPoint2
                ? numberOfDigitsAfterFloatingPoint1
                : numberOfDigitsAfterFloatingPoint2;
        }

        private int GetDecimalFromChar(char ch)
        {
            if (char.IsDigit(ch))
            {
                return Convert.ToInt32(ch.ToString());
            }

            return ch - 65 + 10;
        }

        private char GetCharFromDecimal(int number)
        {
            return number < 10 
                ? Convert.ToChar(number.ToString()) 
                : Convert.ToChar(65 + number - 10);
        }

        private char GetCharSum(char ch1, char ch2)
        {
            int ch1Decimal = GetDecimalFromChar(ch1);
            int ch2Decimal = GetDecimalFromChar(ch2);

            return GetCharFromDecimal(ch1Decimal + ch2Decimal);
        }
    }
}
