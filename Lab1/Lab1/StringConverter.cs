using System;

namespace ConsoleApplication1
{
    public static class DoubleToStringConverter
    {
        public static string ConvertDoubleToBinary(this double number)
        {
            if (double.IsNaN(number))
                return null;
            long bits = BitConverter.DoubleToInt64Bits(number);
            string binary = Convert.ToString(bits, 2).PadLeft(64, '0');
            return binary;
        }
    }
}