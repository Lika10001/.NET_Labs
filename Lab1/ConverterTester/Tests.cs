using NUnit.Framework;
using ConsoleApplication1;

namespace ConverterTester
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void ConvertDoubleToBinary_ValidPositiveInput()
        {
            double number = 123.5;
            string expected = "0100000001011110111000000000000000000000000000000000000000000000";
            string result = number.ConvertDoubleToBinary();
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void ConvertDoubleToBinary_ValidNegativeSmallInput()
        {
            double number = -0.1;
            string expected = "1011111110111001100110011001100110011001100110011001100110011010";
            string result = number.ConvertDoubleToBinary();
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void ConvertDoubleToBinary_ValidPIInput()
        {
            double number = 3.141592653589793;
            string expected = "0100000000001001001000011111101101010100010001000010110100011000";
            string result = number.ConvertDoubleToBinary();
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void ConvertDoubleToBinary_ValidNegativeInput()
        {
            double number = -999999999;
            string expected = "1100000111001101110011010110010011111111100000000000000000000000";
            string result = number.ConvertDoubleToBinary();
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void ConvertDoubleToBinary_ValidMaxValueInput()
        {
            double number = double.MaxValue;
            string expected = "0111111111101111111111111111111111111111111111111111111111111111";
            string result = number.ConvertDoubleToBinary();
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void ConvertDoubleToBinary_ValidMinValueInput()
        {
            double number = double.MinValue;
            string expected = "1111111111101111111111111111111111111111111111111111111111111111";
            string result = number.ConvertDoubleToBinary();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ConvertDoubleToBinary_InvalidInput()
        {
            double number = double.NaN;
            string result = number.ConvertDoubleToBinary();
            Assert.IsNull(result);
        }
        
        [Test]
        public void ConvertDoubleToBinary_NegativeInfinity()
        {
            double number = double.NegativeInfinity;
            string expectedBinary = "1111111111110000000000000000000000000000000000000000000000000000";
            string actualBinary = number.ConvertDoubleToBinary();
            Assert.AreEqual(expectedBinary, actualBinary);
        }
        
        [Test]
        public void ConvertDoubleToBinary_PositiveInfinity()
        {
            double number = double.PositiveInfinity;
            string expectedBinary = "0111111111110000000000000000000000000000000000000000000000000000";
            string actualBinary = number.ConvertDoubleToBinary();
            Assert.AreEqual(expectedBinary, actualBinary);
        }
    }
}