using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_6
{
    // Интерфейс для работы с дробями
    public interface IFraction
    {
        double GetRealValue();
        void SetNumerator(int numerator);
        void SetDenominator(int denominator);
    }

    // Класс для работы с дробями
    public class Fraction : IFraction, ICloneable
    {
        public int Numerator { get; private set; }
        public int Denominator { get; private set; }

        private double? IsRealValue;

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Знаменатель не может быть равен нулю.");
            }
            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }
            Numerator = numerator;
            Denominator = denominator;
            Simplify();
        }

        public override string ToString()
        {
            if (Denominator == 1)
            {
                return Numerator.ToString();
            }
            return $"{Numerator}/{Denominator}";
        }

        private void Simplify()
        {
            int gcd = GCD(Numerator, Denominator);
            Numerator /= gcd;
            Denominator /= gcd;
            IsRealValue = null; // Сделать недействительным кэшированное реальное значение
        }

        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return Math.Abs(a);
        }

        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            int newNumerator = f1.Numerator * f2.Denominator + f2.Numerator * f1.Denominator;
            int newDenominator = f1.Denominator * f2.Denominator;
            return new Fraction(newNumerator, newDenominator);
        }

        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            int newNumerator = f1.Numerator * f2.Denominator - f2.Numerator * f1.Denominator;
            int newDenominator = f1.Denominator * f2.Denominator;
            return new Fraction(newNumerator, newDenominator);
        }

        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            int newNumerator = f1.Numerator * f2.Numerator;
            int newDenominator = f1.Denominator * f2.Denominator;
            return new Fraction(newNumerator, newDenominator);
        }

        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            if (f2.Numerator == 0)
            {
                throw new DivideByZeroException("Деление на ноль.");
            }
            int newNumerator = f1.Numerator * f2.Denominator;
            int newDenominator = f1.Denominator * f2.Numerator;
            return new Fraction(newNumerator, newDenominator);
        }

        public static Fraction operator +(Fraction f, int n)
        {
            return f + new Fraction(n, 1);
        }

        public static Fraction operator -(Fraction f, int n)
        {
            return f - new Fraction(n, 1);
        }

        public static Fraction operator *(Fraction f, int n)
        {
            return f * new Fraction(n, 1);
        }

        public static Fraction operator /(Fraction f, int n)
        {
            if (n == 0)
            {
                throw new DivideByZeroException("Деление на ноль.");
            }
            return f / new Fraction(n, 1);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Fraction other = (Fraction)obj;
            return Numerator == other.Numerator && Denominator == other.Denominator;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Numerator, Denominator);
        }


        public object Clone()
        {
            return new Fraction(Numerator, Denominator);
        }

        public double GetRealValue()
        {
            if (IsRealValue == null)
            {
                IsRealValue = (double)Numerator / Denominator;
            }
            return IsRealValue.Value;
        }

        public void SetNumerator(int numerator)
        {
            Numerator = numerator;
            Simplify();
        }

        public void SetDenominator(int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Знаменатель не может быть равен нулю.");
            }
            Denominator = denominator;
            Simplify();
        }
    }
}
