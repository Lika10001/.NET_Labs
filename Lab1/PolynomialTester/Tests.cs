using System;
using ConsoleApplication1;
using NUnit.Framework;

namespace PolynomialTester
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void toString_ReturnsCorrectStringRepresentation()
        {
            string expectedResult = "2 - 1x^2 + 8x^3 + 10x^4 - 333333x^6";
            Polynomial testPolynomial = new Polynomial(2, 0, -1, 8, 10, 0, -333333);
            string actualResult = testPolynomial.ToString();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Equal_ReturnsTrueForEqualPolynomials()
        {
            Polynomial testPolynomial1 = new Polynomial(111, 222, 0, 44);
            Polynomial testPolynomial2 = new Polynomial(111, 222, 0, 44);
            bool actualResult = testPolynomial1.Equals(testPolynomial2);
            Assert.IsTrue(actualResult);
        }

        [Test]
        public void Equal_ReturnsTrueForZeroPolynomial()
        {
            Polynomial testPolynomial1 = new Polynomial(0);
            Polynomial testPolynomial2 = new Polynomial(0);
            Assert.IsTrue(testPolynomial1.Equals(testPolynomial2));
        }

        [Test]
        public void Equal_ReturnsFalseForNotEqualPolynomialsWithDifferentDegree()
        {
            Polynomial testPolynomial1 = new Polynomial(12, 999999, -18, 0);
            Polynomial testPolynomial2 = new Polynomial(-99, 103, 8);
            bool actualResult = testPolynomial1.Equals(testPolynomial2);
            Assert.IsFalse(actualResult);
        }
        
        [Test]
        public void Equal_ReturnsFalseForNotEqualPolynomialsWithSameDegree()
        {
            Polynomial testPolynomial1 = new Polynomial(12, 999999, -18, 8);
            Polynomial testPolynomial2 = new Polynomial(-99, 103, 8, 9);
            bool actualResult = testPolynomial1.Equals(testPolynomial2);
            Assert.IsFalse(actualResult);
        }

        [Test]
        public void GetHash_ReturnsTrueForCorrectHashForPolynomial()
        {
            double expectedResult = 1110245376;
            Polynomial testPolynomial = new Polynomial(100, 200, 300, 400, 500);
            double actualResult = testPolynomial.GetHashCode();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetHash_ReturnsTrueForEqualPolynomials()
        {
            Polynomial testPolynomial1 = new Polynomial(100, 200, 300);
            Polynomial testPolynomial2 = new Polynomial(100, 200, 300);
            bool actualResult = (testPolynomial1.GetHashCode() == testPolynomial2.GetHashCode());
            Assert.IsTrue(actualResult);
        }

        [Test]
        public void GetHash_ReturnsFalseForDifferentPolynomials()
        {
            Polynomial testPolynomial1 = new Polynomial(2, 0, 0, 1);
            Polynomial testPolynomial2 = new Polynomial(99, 22, 1001);
            bool actualResult = (testPolynomial1.GetHashCode() == testPolynomial2.GetHashCode());
            Assert.IsFalse(actualResult);
        }

        [Test]
        public void Evaluate_ReturnsTrueForCorrectValue()
        {
            double expectedResult = 15;
            Polynomial testPolynomial = new Polynomial(100, 200, 300, 400, 500);
            double xValue = 0.01;
            double actualResult = testPolynomial.Evaluate(xValue);
            bool result = Convert.ToBoolean(actualResult.CompareTo(expectedResult));
            Assert.IsTrue(result);
        }
        
        [Test]
        public void Add_ReturnsTrueForCorrectResultSameDegree()
        {
            Polynomial expectedResult = new Polynomial(-87,1000102,-10,17);
            Polynomial testPolynomial1 = new Polynomial(12, 999999, -18, 8);
            Polynomial testPolynomial2 = new Polynomial(-99, 103, 8, 9);
            Polynomial actualResult = testPolynomial1.Add(testPolynomial2);
            Assert.IsTrue(expectedResult.Equals(actualResult));
        }
        
        [Test]
        public void Add_ReturnsTrueForCorrectResultDifferentDegree()
        {
            Polynomial expectedResult = new Polynomial(-87,1000102,-10, 17,100);
            Polynomial testPolynomial1 = new Polynomial(12, 999999, -18, 8, 100);
            Polynomial testPolynomial2 = new Polynomial(-99, 103, 8, 9);
            Polynomial actualResult = testPolynomial1.Add(testPolynomial2);
            Assert.IsTrue(expectedResult.Equals(actualResult));
        }
        
        [Test]
        public void Add_ReturnsTrueForCorrectResultThreePolynomials()
        {
            Polynomial expectedResult = new Polynomial(-8.2,1000135,-17, 8.01, 100);
            Polynomial testPolynomial1 = new Polynomial(12, 999999, -18, 8, 100);
            Polynomial testPolynomial2 = new Polynomial(-99, 103, 8);
            Polynomial testPolynomial3 = new Polynomial(78.8, 33, -7, 0.01);
            Polynomial actualResult = testPolynomial1.Add(testPolynomial2, testPolynomial3);
            Assert.IsTrue(expectedResult.Equals(actualResult));
        }
        
        [Test]
        public void Subtract_ReturnsTrueForCorrectResultSameDegree()
        {
            Polynomial expectedResult = new Polynomial(111, 999896,-26,-1);
            Polynomial testPolynomial1 = new Polynomial(12, 999999, -18, 8);
            Polynomial testPolynomial2 = new Polynomial(-99, 103, 8, 9);
            Polynomial actualResult = testPolynomial1.Subtract(testPolynomial2);
            Assert.IsTrue(expectedResult.Equals(actualResult));
        }
        
        [Test]
        public void Subtract_ReturnsTrueForCorrectResultDifferentDegree()
        {
            Polynomial expectedResult = new Polynomial(111, 999896,-26, -1, 100);
            Polynomial testPolynomial1 = new Polynomial(12, 999999, -18, 8, 100);
            Polynomial testPolynomial2 = new Polynomial(-99, 103, 8, 9);
            Polynomial actualResult = testPolynomial1.Subtract(testPolynomial2);
            Assert.IsTrue(expectedResult.Equals(actualResult));
        }
        
        [Test]
        public void Subtract_ReturnsTrueForCorrectResultThreePolynomials()
        {
            Polynomial expectedResult = new Polynomial(32.2, 999863,-19, 7.99, 100);
            Polynomial testPolynomial1 = new Polynomial(12, 999999, -18, 8, 100);
            Polynomial testPolynomial2 = new Polynomial(-99, 103, 8);
            Polynomial testPolynomial3 = new Polynomial(78.8, 33, -7, 0.01);
            Polynomial actualResult = testPolynomial1.Subtract(testPolynomial2, testPolynomial3);
            Assert.IsTrue(expectedResult.Equals(actualResult));
        }

        [Test]
        public void Multiply_ReturnsTrueForCorrectResult()
        {
            Polynomial expectedResult = new Polynomial(-1188, -98998665,103001775, 7997454, 8990771, 10202, 872, 900);
            Polynomial testPolynomial1 = new Polynomial(-99, 103, 8, 9);
            Polynomial testPolynomial2 = new Polynomial(12, 999999, -18, 8, 100);
            Polynomial actualResult = testPolynomial1.Multiply(testPolynomial2);
            Assert.IsTrue(expectedResult.Equals(actualResult));
        }
        
        [Test]
        public void Multiply_ReturnsTrueForCorrectResultThreePolynomials()
        {
            Polynomial expectedResult = new Polynomial(-5940, -494993325, 515005311, -257008725, 353959180, 24043372, 26976673, 35106, 2616, 2700);
            Polynomial testPolynomial1 = new Polynomial(-99, 103, 8, 9);
            Polynomial testPolynomial2 = new Polynomial(12, 999999, -18, 8, 100);
            Polynomial testPolynomial3 = new Polynomial(5, 0, 3);
            Polynomial actualResult = testPolynomial1.Multiply(testPolynomial2, testPolynomial3);
            Assert.IsTrue(expectedResult.Equals(actualResult));
        }
        
        [Test]
        public void Divide_ReturnsTrueForCorrectResultGreaterDegree()
        {
            Polynomial expectedResult = new Polynomial(-4, 1);
            Polynomial testPolynomial1 = new Polynomial(2, -6, 1);
            Polynomial testPolynomial2 = new Polynomial(-2, 1);
            Polynomial[] actualResult = testPolynomial1.Divide(testPolynomial2);
            Assert.IsTrue(expectedResult.Equals(actualResult[0]));
        }
        
        [Test]
        public void Divide_ReturnsTrueForCorrectResultLessDegree()
        {
            Polynomial expectedResult = new Polynomial(0);
            Polynomial testPolynomial1 = new Polynomial(-99, -103, 8, 9);
            Polynomial testPolynomial2 = new Polynomial(12, 999999, -18, 8, 100);
            Polynomial[] actualResult = testPolynomial1.Divide(testPolynomial2);
            Assert.IsTrue(expectedResult.Equals(actualResult[0]));
        }
        
        [Test]
        public void Divide_ReturnsTrueForCorrectResultSameDegree()
        {
            Polynomial expectedResult = new Polynomial(1);
            Polynomial testPolynomial1 = new Polynomial(-99, -103, 8, 9);
            Polynomial testPolynomial2 = new Polynomial(-99, -103, 8, 9);
            Polynomial[] actualResult = testPolynomial1.Divide(testPolynomial2);
            Assert.IsTrue(expectedResult.Equals(actualResult[0]));
        }
        
    }
}