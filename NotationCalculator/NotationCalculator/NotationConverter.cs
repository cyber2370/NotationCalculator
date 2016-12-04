using System;
using System.Linq;

namespace NotationCalculator
{
    public static class NotationConverter
    {
        private static readonly string[] BinaryValues;

        static NotationConverter()
        {
            BinaryValues = new string[]
            {
                "000000", "000001", "000010", "000011", "000100", "000101", "000110", "000111",
                "001000", "001001", "001010", "001011", "001100", "001101", "001110", "001111",
                "010000", "010001", "010010", "010011", "010100", "010101", "010110", "010111",
                "011000", "011001", "011010", "011011", "011100", "011101", "011110", "011111",
                "100000", "100001", "100010", "100011", "100100", "100101", "100110", "100111",
                "101000", "101001", "101010", "101011", "101100", "101101", "101110", "101111",
                "110000", "110001", "110010", "110011", "110100", "110101", "110110", "110111",
                "111000", "111001", "111010", "111011", "111100", "111101", "111110", "111111"
            };
        }

        public static string ConvertToAnyNotation(this string number, int fromNotation, int toNotation)
        {
            string result = "";

            string fractionalPart = "";
            string binaryNumber = "";

            if (number.Contains("."))
            {
                var tmpArr = number.Split('.');

                fractionalPart = ConvertFractionalPart(tmpArr[1], fromNotation, toNotation);
            }
            else
            {
                binaryNumber = ConvertToBinaryNotation(number, fromNotation);
            }


            if (toNotation == 10)
            {
                return ConvertFromBinaryToDecimal(binaryNumber).ToString();
            }

            int numberOfDigitsPerElement = FindNumberOfBinaryDigitsPerSourceDigit(toNotation);
            string[] binaryValues = BinaryValues
                .Take(Convert.ToInt32(Math.Pow(2, numberOfDigitsPerElement)))
                .Select(x => x.Remove(0, x.Length - numberOfDigitsPerElement))
                .ToArray();

            binaryNumber = ComplementBinaryToFullNotation(binaryNumber, numberOfDigitsPerElement);

            while (binaryNumber.Length != 0)
            {
                string entry = string.Join("", binaryNumber.Take(numberOfDigitsPerElement));
                binaryNumber = binaryNumber.Remove(0, numberOfDigitsPerElement);

                int index = Array.IndexOf(binaryValues, entry);
                result += index < 10 ? index.ToString() : Convert.ToChar(65 + (index - 10)).ToString();
            }

            return result + fractionalPart;
        }

        private static string ConvertToBinaryNotation(this string number, int notation)
        {
            if (notation == 2)
            {
                return number;
            }

            if (notation == 10)
            {
                return ConvertFromDecimalToBinary(Convert.ToInt32(number));
            }

            int numberOfDigitsPerElement = FindNumberOfBinaryDigitsPerSourceDigit(notation);
            string[] binaryValues = BinaryValues
                .Take(Convert.ToInt32(Math.Pow(2, numberOfDigitsPerElement)))
                .Select(x => x.Remove(0, x.Length - numberOfDigitsPerElement))
                .ToArray();

            string result = "";

            for (int i = 0; i < number.Length; i++)
            {
                char currentValue = number[i];

                int binaryArrayIndex;
                bool isConvertSuccess = int.TryParse(currentValue.ToString(), out binaryArrayIndex);

                if (!isConvertSuccess)
                {
                    binaryArrayIndex = 10 + Convert.ToInt32(currentValue - 65);
                }

                result += binaryValues[binaryArrayIndex];
            }

            return result;
        }

        private static int ConvertFromBinaryToDecimal(string binary)
        {
            int result = 0;

            for (int i = binary.Length - 1; i >= 0; i--)
            {
                if (binary[i] == '0')
                    continue;

                result += Convert.ToInt32(Math.Pow(2, binary.Length - i - 1));
            }

            return result;
        }

        private static string ConvertFromDecimalToBinary(int decimalNumber)
        {
            if (decimalNumber == 0)
            {
                return "000";
            }

            string result = "";

            while (decimalNumber != 0)
            {
                if (decimalNumber%2 == 1)
                {
                    result += "1";
                    decimalNumber--;
                }
                else
                {
                    result += "0";
                }

                decimalNumber /= 2;
            }

            return string.Join("", result.Reverse());
        }

        private static string ComplementBinaryToFullNotation(
            string binary,
            int numberOfDigitsPerElement)
        {
            int modulo = binary.Length%numberOfDigitsPerElement;

            if (modulo == 0)
                return binary;

            modulo = numberOfDigitsPerElement - modulo;

            for (int i = 0; i < modulo; i++)
            {
                binary = "0" + binary;
            }

            return binary;
        }

        private static int FindNumberOfBinaryDigitsPerSourceDigit(int notation)
        {
            int value, powerCounter;

            for (value = 2, powerCounter = 1; value < notation; value *= 2, powerCounter++)
            {
            }

            return powerCounter;
        }

        private static string ConvertFractionalPart(string fractional, int from, int to)
        {
            if (from == to)
            {
                return "." + fractional;
            }

            if (to == 10)
            {
                return "." + ConvertToDecimalFractionalPart(fractional, from);
            }

            if (from == 10)
            {
                return "." + ConvertDecimalFractionalPart(fractional, to);
            }

            var decimalFract = ConvertToDecimalFractionalPart(fractional, from);
            return "." + ConvertDecimalFractionalPart(decimalFract, to);
        }

        private static string ConvertToDecimalFractionalPart(string fractionalPart, int notation)
        {
            double result = 0;

            for (int i = 0; i < 20 && i < fractionalPart.Length; i++)
            {
                result += GetDecimalFromChar(fractionalPart[i]) / Math.Pow(notation, i + 1);
            }
            var tmpArr = result.ToString().Replace(",", ".").Split('.');

            return tmpArr[1];
        }

        private static string ConvertDecimalFractionalPart(string fractionalPart, int notation)
        {
            string result = "";
            fractionalPart = "0." + fractionalPart;

            for (int i = 0; i < 10; i++)
            {
                var mc = new NotationCalculator(notation, fractionalPart, notation.ToString());

                fractionalPart = mc.GetMultiply();

                if (Compare(fractionalPart, 1.ToString(), notation) == -1)
                {
                    result += "0";
                }
                else
                {
                    var tmpArr = fractionalPart.Split('.');
                    result += tmpArr[0];

                    if (tmpArr.Length == 1)
                    {
                        break;
                    }

                    fractionalPart = tmpArr[1];
                }
            }

            return "." + result;
        }

        private static int Compare(string first, string second, int notation)
        {
            var nc = new NotationCalculator(notation, first, second);

            return nc.Compare();
        }

        private static int GetDecimalFromChar(char ch)
        {
            if (char.IsDigit(ch))
            {
                return Convert.ToInt32(ch.ToString());
            }

            return ch - 65 + 10;
        }

        private static char GetCharFromDecimal(int number)
        {
            return number < 10
                ? Convert.ToChar(number.ToString())
                : Convert.ToChar(65 + number - 10);
        }
    }
}