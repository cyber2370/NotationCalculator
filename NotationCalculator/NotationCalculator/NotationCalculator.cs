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

            SetupDigits(ref _firstDigit, ref _secondDigit);
        }

        public string GetSum()
        {
            string result = GetSum(_firstDigit, _secondDigit);

            return TrimZeros(ref result);
        }

        public string GetSubtraction()
        {
            string result = GetSubtraction(_firstDigit, _secondDigit);

            return TrimZeros(ref result);
        }

        public string GetMultiply()
        {
            string result = "";
            string firstDigit = _firstDigit.Replace(".", "");
            string secondDigit = _secondDigit.Replace(".", "");

            int digitsAfterFloatingPoint = 
                GetDigitsAfterFloatingPoint(_firstDigit)
              + GetDigitsAfterFloatingPoint(_secondDigit);

            for (int i = secondDigit.Length - 1; i >= 0; i--)
            {
                int currentValueOfSecond = GetDecimalFromChar(secondDigit[i]);
                string tempResult = "";
                int toNextDigit = 0;

                for (int j = firstDigit.Length - 1; j >= 0; j--)
                {
                    int currentValueOfFirst = GetDecimalFromChar(firstDigit[j]);

                    int resultOfMultiple = currentValueOfFirst*currentValueOfSecond + toNextDigit;

                    toNextDigit = Convert.ToInt32( (resultOfMultiple/_notation)^0 );
                    int toCurrentDigit = resultOfMultiple - toNextDigit * _notation;

                    //to current digit
                    tempResult = GetCharFromDecimal(toCurrentDigit) + tempResult;
                }

                tempResult = toNextDigit + tempResult;

                for (int j = 0; j < secondDigit.Length - 1 - i; j++)
                {
                    tempResult += "0";
                }

                SetupDigits(ref result, ref tempResult);

                result = GetSum(tempResult, result);
            }

            // setting floating point
            if (digitsAfterFloatingPoint != 0)
            {
                result = new StringBuilder(result).Insert(result.Length - digitsAfterFloatingPoint, ".").ToString();
            }
            
            return TrimZeros(ref result);
        }

        public string GetDivision()
        {
            string result      = "",
                   firstDigit  = _firstDigit, 
                   secondDigit = _secondDigit;

            /*Console.WriteLine($"Start dividing {firstDigit} by {secondDigit};\n" +
                              $"----------------------------\n\n");


            Console.WriteLine($"----** (Befort) Setup Digits For Division **----\n" +
                              $"{nameof(firstDigit)}: {firstDigit}\n" +
                              $"{nameof(secondDigit)}: {secondDigit}\n" +
                              $"----------------------------");*/

            SetupDigitsForDivision(ref firstDigit, ref secondDigit);

            /*Console.WriteLine($"----** (After) Setup Digits For Division **----\n" +
                              $"{nameof(firstDigit)}: {firstDigit}\n" +
                              $"{nameof(secondDigit)}: {secondDigit}\n" +
                              $"----------------------------\n\n");*/

            if (secondDigit.TrimStart('0') == "" || firstDigit.TrimStart('0') == "")
            {
                return "Infinity";
            }

            StringBuilder dividend = new StringBuilder(firstDigit);
            string dividendPart = "";

            //Console.WriteLine($"----** Starting Dividing... **----\n");

            while (dividend.Length != 0 || dividendPart.TrimStart('0').Length != 0)
            {
                /*Console.WriteLine($"----** New Iteration **----\n" +
                                  $"{nameof(result)}: {result}\n" +
                                  $"{nameof(dividend)}: {dividend}\n");*/
                bool isDividendPartCorrect = false;

                /*Console.WriteLine($"-----** (Before) Creating Part of Dividend " +
                                  $"{nameof(dividend)}: {dividend};\n" +
                                  $"{nameof(dividendPart)}: {dividendPart}\n" +
                                  $"{nameof(isDividendPartCorrect)}: {isDividendPartCorrect}");*/
                while (!isDividendPartCorrect && dividend.Length != 0)
                {
                    dividendPart += dividend[0];
                    dividend.Remove(0, 1);

                    isDividendPartCorrect = Compare(dividendPart, secondDigit) < 1;

                    if (!isDividendPartCorrect)
                    {
                        result += "0";
                    }
                }
                /*Console.WriteLine($"-----** (After) Creating Part of Dividend ({nameof(dividend.Length)} == 0 or {nameof(dividendPart)} < {nameof(secondDigit)} ) **-----\n" +
                                  $"{nameof(dividend)}: {dividend};\n" +
                                  $"{nameof(dividendPart)}: {dividendPart}\n" +
                                  $"{nameof(isDividendPartCorrect)}: {isDividendPartCorrect}\n\n");

                Console.WriteLine($"-----** (Before) Continue create part of dividend **-----\n" +
                                  $"{nameof(result)}: {result};\n" +
                                  $"{nameof(dividendPart)}: {dividendPart}");*/
                while (!isDividendPartCorrect)
                {
                    dividendPart += "0";

                    if (!result.Contains('.'))
                    {
                        result += ".";
                    }

                    isDividendPartCorrect = Compare(dividendPart, secondDigit) < 1;

                    if (!isDividendPartCorrect)
                    {
                        result += "0";
                    }

                    //check for number of digits after float point
                    var tmpArr = result.Split('.');
                    if (tmpArr.Length > 1 && tmpArr[1].Length > 15)
                    {
                        return TrimZeros(ref result);
                    }
                }
                /*Console.WriteLine($"-----** (After) Continue create part of dividend **-----\n" +
                                  $"{nameof(result)}: {result};\n" +
                                  $"{nameof(dividendPart)}: {dividendPart}\n\n");*/
                
                int toCurrentDigit = 0;
                /*Console.WriteLine($"-----** (Before) Get Modulo (dividendPart >= secondDigit) **-----\n" +
                                  $"{nameof(toCurrentDigit)}: {toCurrentDigit}\n" +
                                  $"{nameof(dividendPart)}: {dividendPart}");*/
                // TODO: rewrite when converter will be implement
                while (Compare(dividendPart, secondDigit) != 1)
                {
                    toCurrentDigit++;
                    dividendPart = GetSubtraction(dividendPart, secondDigit);
                }
                /*Console.WriteLine($"-----** (After) Get Modulo (dividendPart >= secondDigit) **-----\n" +
                                  $"{nameof(toCurrentDigit)}: {toCurrentDigit}\n" +
                                  $"{nameof(dividendPart)}: {dividendPart}\n\n");

                Console.WriteLine(
                    $"-----** (Before) Updating result **-----\n" +
                    $"{nameof(result)}: {result}");*/

                result += GetCharFromDecimal(toCurrentDigit);

                /*Console.WriteLine($"-----** (After)  Updating result **-----\n" +
                                  $"{nameof(result)}: {result}\n\n");*/
            }

            return TrimZeros(ref result);
        }

        private string GetSubtraction(string firstDigit, string secondDigit)
        {
            bool isNegativeResult = false;

            SetupDigits(ref firstDigit, ref secondDigit);

            if (Compare(firstDigit, secondDigit) == 0)
            {
                return "0";
            }

            // if second number is bigger than first number
            if (Compare(firstDigit, secondDigit) > -1)
            {
                var tmp = firstDigit;
                firstDigit = secondDigit;
                secondDigit = tmp;

                isNegativeResult = true;
            }

            string result = "";
            string firstDigitWithoutFloatPoint = firstDigit.Replace(".", "");
            string secondDigitWithoutFloatPoint = secondDigit.Replace(".", "");

            int digitsAfterFloatingPoint = GetMaxDigitsAfterFloatingPoint(firstDigit, secondDigit);

            bool isNextDigitOccupied = false;
            for (int i = firstDigitWithoutFloatPoint.Length - 1; i >= 0; i--)
            {
                int currentDigitValue1 = GetDecimalFromChar(firstDigitWithoutFloatPoint[i]) - (isNextDigitOccupied ? 1 : 0);
                int currentDigitValue2 = GetDecimalFromChar(secondDigitWithoutFloatPoint[i]);

                isNextDigitOccupied = false;

                if (currentDigitValue1 < currentDigitValue2)
                {
                    currentDigitValue1 += _notation;
                    isNextDigitOccupied = true;
                }

                int currentDigitValueResult = currentDigitValue1 - currentDigitValue2;
                char currentDigitCharResult = GetCharFromDecimal(currentDigitValueResult);

                result = currentDigitCharResult + result;
            }

            if (digitsAfterFloatingPoint != 0)
            {
                result = new StringBuilder(result).Insert(result.Length - digitsAfterFloatingPoint, ".").ToString();
            }

            TrimZeros(ref result);

            return isNegativeResult ? $"-{result}" : result;
        }

        private string GetSum(string firstDigit, string secondDigit)
        {
            StringBuilder resultStringBuilder = new StringBuilder(firstDigit.Replace(".", ""));
            secondDigit = secondDigit.Replace(".", "");

            int digitsAfterFloatingPoint = GetMaxDigitsAfterFloatingPoint(firstDigit, secondDigit);

            for (int i = secondDigit.Length - 1; i >= 0; i--)
            {
                int currentValueFromResult = GetDecimalFromChar(resultStringBuilder[i]),
                    currentValueFromSecondNumber = GetDecimalFromChar(secondDigit[i]),
                    nextDigitValue = 0;

                int tmpResult = currentValueFromSecondNumber + currentValueFromResult;

                if (tmpResult /_notation >= 1)
                {
                    nextDigitValue = Convert.ToInt32(Math.Floor((double) tmpResult / _notation));
                    tmpResult = tmpResult%_notation;
                }

                resultStringBuilder[i] = GetCharFromDecimal(tmpResult);

                if (i != 0)
                {
                    resultStringBuilder[i - 1] = GetCharSum(resultStringBuilder[i - 1], GetCharFromDecimal(nextDigitValue));
                }
                else
                {
                    resultStringBuilder.Insert(0, GetCharFromDecimal(nextDigitValue));
                }
            }

            if (digitsAfterFloatingPoint != 0)
            {
                resultStringBuilder.Insert(resultStringBuilder.Length - digitsAfterFloatingPoint, ".");
            }

            return resultStringBuilder.ToString();
        }

        private int Compare(string firstDigit, string secondDigit)
        {
            TrimZeros(ref firstDigit);
            TrimZeros(ref secondDigit);

            if (firstDigit == secondDigit)
            {
                return 0;
            }

            string[] firstArr = firstDigit.Split('.');
            string[] secondArr = secondDigit.Split('.');

            if (firstArr[0].Length > secondArr[0].Length)
            {
                return -1;
            }

            if (firstArr[0].Length < secondArr[0].Length)
            {
                return 1;
            }

            for (int i = 0; i < firstArr[0].Length; i++)
            {
                var firstCurrentCharValue = GetDecimalFromChar(firstArr[0][i]);
                var secondCurrentCharValue = GetDecimalFromChar(secondArr[0][i]);

                if (firstCurrentCharValue > secondCurrentCharValue)
                    return -1;

                if (firstCurrentCharValue < secondCurrentCharValue)
                    return 1;
            }

            if (firstArr.Length > secondArr.Length)
                return -1;

            if (firstArr.Length < secondArr.Length)
                return 1;

            for (int i = 0; i < firstArr[1].Length && i < secondArr[1].Length; i++)
            {
                var firstCurrentCharValue = GetDecimalFromChar(firstArr[1][i]);
                var secondCurrentCharValue = GetDecimalFromChar(secondArr[1][i]);

                if (firstCurrentCharValue > secondCurrentCharValue)
                    return -1;

                if (firstCurrentCharValue < secondCurrentCharValue)
                    return 1;
            }

            return firstArr[1].Length > secondArr[1].Length ? -1 : 1;
        }

        private void SetupDigits(ref string firstDigit, ref string secondDigit)
        {
            SetupLengthOfNumbers(ref firstDigit, ref secondDigit);
            
            SetupFloatingPoint(ref firstDigit, ref secondDigit);
        }

        private void SetupDigitsForDivision(ref string firstNumber, ref string secondNumber)
        {
            firstNumber = TrimZeros(ref firstNumber);
            secondNumber = TrimZeros(ref secondNumber);

            var realAndFractionalPartsOfFirstNumber = firstNumber.Split('.');
            var realAndFractionalPartsOfSecondNumber = secondNumber.Split('.');

            int numbersLengthAfterFractionalPointOfFirstNumber = 
                realAndFractionalPartsOfFirstNumber.Length > 1 ? realAndFractionalPartsOfFirstNumber[1].Length : 0;
            int numbersLengthAfterFractionalPointOfSecondNumber = 
                realAndFractionalPartsOfSecondNumber.Length > 1 ? realAndFractionalPartsOfSecondNumber[1].Length : 0;

            int difference = 
                numbersLengthAfterFractionalPointOfFirstNumber - numbersLengthAfterFractionalPointOfSecondNumber;

            firstNumber = firstNumber.Replace(".", "");
            secondNumber = secondNumber.Replace(".", "");

            if (difference > 0)
            {
                for (int i = 0; i < difference; i++)
                    secondNumber += "0";
            }
            else if (difference < 0)
            {
                for (int i = 0; i > difference; i--)
                    firstNumber += "0";
            }
        }

        private string TrimZeros(ref string number)
        {
            string[] arr = number.Split('.');

            string realPart = arr[0].TrimStart('0', ' ');
            string fractionalPart = "";

            if (arr.Length > 1)
            {
                fractionalPart = "." + arr[1].TrimEnd('0', ' ');
            }

            number = (realPart.Length > 0 ? realPart : "0") + fractionalPart;
            return number;
        }

        private void SetupLengthOfNumbers(ref string firstDigit, ref string secondDigit)
        {
            string realPartOfFirst = firstDigit.Split('.')[0];
            string realPartOfSecond = secondDigit.Split('.')[0];

            int difference = realPartOfFirst.Length - realPartOfSecond.Length;

            if (difference == 0)
                return;

            if (difference > 0)
            {
                for (int i = 0; i < difference; i++)
                    secondDigit = "0" + secondDigit;
            }
            else
            {
                for (int i = 0; i < -difference; i++)
                    firstDigit = "0" + firstDigit;
            }
        }

        private void SetupFloatingPoint(ref string firstDigit, ref string secondDigit)
        {
            string[] splittedFirstNumber = firstDigit.Split('.');
            string[] splittedSecondNumber = secondDigit.Split('.');

            if (splittedFirstNumber.Length > 1 && splittedSecondNumber.Length > 1)
            {
                string firstNumberFloatPart = splittedFirstNumber[1];
                string secondNumberFloatPart = splittedSecondNumber[1];

                if (firstNumberFloatPart.Length > secondNumberFloatPart.Length)
                {
                    for (int i = 0, diff = firstNumberFloatPart.Length - secondNumberFloatPart.Length;
                        i < diff; i++)
                    {
                        secondDigit += "0";
                    }
                }
                else
                {
                    for (int i = 0, diff = secondNumberFloatPart.Length - firstNumberFloatPart.Length;
                        i < diff; i++)
                    {
                        firstDigit += "0";
                    }
                }
            }
            else if (splittedFirstNumber.Length > 1)
            {
                secondDigit += ".";

                for (int i = 0, length = splittedFirstNumber[1].Length; i < length; i++)
                {
                    secondDigit += "0";
                }
            }
            else if (splittedSecondNumber.Length > 1)
            {
                firstDigit += ".";

                for (int i = 0, length = splittedSecondNumber[1].Length; i < length; i++)
                {
                    firstDigit += "0";
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

        private int GetDigitsAfterFloatingPoint(string number)
        {
            if (number.Contains("."))
            {
                return number.Split('.')[1].Length;
            }

            return 0;
        }

        private int GetMaxDigitsAfterFloatingPoint(string firstDigit, string secondDigit)
        {
            int numberOfDigitsAfterFloatingPoint1 = GetDigitsAfterFloatingPoint(firstDigit),
                numberOfDigitsAfterFloatingPoint2 = GetDigitsAfterFloatingPoint(secondDigit);

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
