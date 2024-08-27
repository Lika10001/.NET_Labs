using System;

namespace ConsoleApplication1
{
    public class Polynomial
    {
        private int XDegree { get; }
        private double[] Coefficients { get; }

        public Polynomial(params double[] coefficients)
        {
            Coefficients = coefficients ?? throw new ArgumentNullException(nameof(coefficients));
            XDegree = coefficients.Length - 1;
        }

        public double Evaluate(double x)
        {
            double result = 0;
            for (int i = 0; i < Coefficients.Length; i++)
            {
                result += Coefficients[i] * Math.Pow(x, i);
            }
            return result;
        }

        public Polynomial Add(Polynomial other)
        {
            int maxLength = Math.Max(Coefficients.Length, other.Coefficients.Length);
            double[] newCoefficients = new double[maxLength];
            for (int i = 0; i < maxLength; i++)
            {
                double firstCoefficient = (i < Coefficients.Length) ?Coefficients[i]:0;
                double secCoefficient = (i < other.Coefficients.Length) ? other.Coefficients[i] : 0;
                newCoefficients[i] = firstCoefficient + secCoefficient;
            }
            return new Polynomial(newCoefficients);
        }
        
        public Polynomial Add(Polynomial polynomial1, Polynomial polynomial2)
        {       
            int maxLength = Math.Max(Coefficients.Length, polynomial1.Coefficients.Length);
            maxLength = Math.Max(maxLength, polynomial2.Coefficients.Length);
            double[] newCoefficients = new double[maxLength];
            for (int i = 0; i < maxLength; i++)
            {
                double firstCoefficient = (i < Coefficients.Length) ?Coefficients[i]:0;
                double secCoefficient = (i < polynomial1.Coefficients.Length) ? polynomial1.Coefficients[i] : 0;
                double thirdCoefficient = (i < polynomial2.Coefficients.Length) ? polynomial2.Coefficients[i] : 0;
                newCoefficients[i] = firstCoefficient + secCoefficient + thirdCoefficient;
            }
            return new Polynomial(newCoefficients);
        }

        public Polynomial Subtract(Polynomial other)
        {
            int maxLength = Math.Max(Coefficients.Length, other.Coefficients.Length);
            double[] newCoefficients = new double[maxLength];
            for (int i = 0; i < maxLength; i++)
            {
                double firstCoefficient = (i < Coefficients.Length) ?Coefficients[i] : 0;
                double secCoefficient = (i < other.Coefficients.Length) ? other.Coefficients[i] : 0;
                newCoefficients[i] = firstCoefficient - secCoefficient;
            }
            return new Polynomial(newCoefficients);
        }
        
        public Polynomial Subtract(Polynomial polynomial1, Polynomial polynomial2)
        {
            int maxLength = Math.Max(Coefficients.Length, polynomial1.Coefficients.Length);
            maxLength = Math.Max(maxLength, polynomial2.Coefficients.Length);
            double[] newCoefficients = new double[maxLength];
            for (int i = 0; i < maxLength; i++)
            {
                double firstCoefficient = (i < Coefficients.Length) ?Coefficients[i] : 0;
                double secCoefficient = (i < polynomial1.Coefficients.Length) ? polynomial1.Coefficients[i] : 0;
                double thirdCoefficient = (i < polynomial2.Coefficients.Length) ? polynomial2.Coefficients[i] : 0;
                newCoefficients[i] = firstCoefficient - secCoefficient - thirdCoefficient;
            }
            return new Polynomial(newCoefficients);
        }

        public Polynomial Multiply(Polynomial other)
        {
            int newLength = Coefficients.Length + other.Coefficients.Length - 1;
            double[] newCoefficients = new double[newLength];
            for (int i = 0; i < Coefficients.Length; i++) {
                for (int j = 0; j < other.Coefficients.Length; j++)
                {
                    newCoefficients[i + j] += Coefficients[i] * other.Coefficients[j];
                }
            }
            return new Polynomial(newCoefficients);
        }
        
        public Polynomial Multiply(Polynomial polynomial1, Polynomial polynomial2)
        {
            int newLength = Coefficients.Length + polynomial1.Coefficients.Length - 1;
            double[] newCoefficients = new double[newLength];
            for (int i = 0;
                 i < Coefficients.Length; i++) {
                for (int j = 0; j < polynomial1.Coefficients.Length; j++)
                {
                    newCoefficients[i + j] += Coefficients[i] * polynomial1.Coefficients[j];
                }
            }
            Polynomial newPolynomial = new Polynomial(newCoefficients);
            
            newLength = newPolynomial.Coefficients.Length + polynomial2.Coefficients.Length - 1;
            double[] resultCoefficients = new double[newLength];
            for (int i = 0; i < newPolynomial.Coefficients.Length; i++) {
                for (int j = 0; j < polynomial2.Coefficients.Length; j++)
                {
                    resultCoefficients[i + j] += newPolynomial.Coefficients[i] * polynomial2.Coefficients[j];
                }
            }
            return new Polynomial(resultCoefficients);
        }

        public Polynomial[] Divide(Polynomial divider)//first element in array - remainder, second - quotient
        {
            Polynomial[] resultArray = new Polynomial[2];
            int dividendDegree = XDegree;
            int dividerDegree = divider.XDegree;
            if (dividerDegree > dividendDegree)
            {
                resultArray[0] = new Polynomial(0);
                resultArray[1] = new Polynomial(Coefficients);
                return resultArray;
            }
            double[] remainderCoefficients = new double[dividendDegree - dividerDegree + 1];
            double[] quotientCoefficients  = (double[])Coefficients.Clone();

            while (dividendDegree >= dividerDegree)
            {
                int degreeDifference = dividendDegree - dividerDegree;
                double remainderCoefficient = quotientCoefficients[quotientCoefficients.Length - 1] / divider.Coefficients[divider.Coefficients.Length - 1];
                remainderCoefficients[degreeDifference] = remainderCoefficient;
                
                for (int i = 0; i <= dividerDegree; i++)
                {
                    quotientCoefficients[quotientCoefficients.Length - i - 1] -= remainderCoefficient * divider.Coefficients[divider.Coefficients.Length - 1 - i];
                }
                Array.Resize(ref quotientCoefficients, quotientCoefficients.Length - 1);
                dividendDegree--;
            }
            resultArray[0] = new Polynomial(remainderCoefficients);
            resultArray[1] = new Polynomial(quotientCoefficients);
            return resultArray;
        }
    
        public override string ToString()
        {
            if (Coefficients != null)
            {
                string result = "";

                for (int i = 0; i < Coefficients.Length; i++)
                {
                    if (Coefficients[i] != 0)
                    {
                        if ((result != "") && (Coefficients[i] > 0))
                        {
                            result += " + ";
                        }
                        else if ((result != "") && (Coefficients[i] < 0))
                        {
                            result += " - ";
                        }

                        if (i == 0)
                        {
                            result += Coefficients[i];
                        }
                        else
                        {
                            result += Math.Abs(Coefficients[i]) + "x^" + i;
                        }
                    }
                }

                return result;
            }
            else
            {
                return null;
            }
        }
    
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Polynomial otherPolynomial = (Polynomial)obj;
            if (Coefficients.Length != otherPolynomial.Coefficients.Length)
            {
                return false;
            }
            for (int i = 0; i < Coefficients.Length; i++)
            {
                if (Math.Round(Coefficients[i], 2).CompareTo(Math.Round(otherPolynomial.Coefficients[i], 2)) != 0)
                {
                    return false;
                }
            }
            return true;
        }
    
        public override int GetHashCode()
        {
            int hashCode = 0;
            foreach (var t in Coefficients)
            {
                hashCode += t.GetHashCode();
            }
            return hashCode;
        }
    }
}