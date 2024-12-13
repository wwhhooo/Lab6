using System;

namespace Lab_6
{
    // Класс для работы с дробями
    public class Fraction : IFraction, ICloneable
    {
        // Свойство для числителя
        public int Numerator { get; private set; }

        // Свойство для знаменателя
        public int Denominator { get; private set; }

        // Кэшированное вещественное значение дроби
        private double? cachedRealValue;

        // Конструктор класса Fraction
        public Fraction(int numerator, int denominator)
        {
            // Проверка на ноль в знаменателе
            if (denominator == 0)
            {
                throw new ArgumentException("Знаменатель не может быть равен нулю.");
            }

            // Нормализация знаменателя и числителя
            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }

            // Установка числителя и знаменателя
            Numerator = numerator;
            Denominator = denominator;

            // Сокращение дроби
            Simplify();
        }

        // Переопределение метода ToString для вывода дроби в строковом формате
        public override string ToString()
        {
            // Если знаменатель равен 1, возвращаем только числитель
            if (Denominator == 1)
            {
                return Numerator.ToString();
            }

            // Возвращаем дробь в формате "числитель/знаменатель"
            return $"{Numerator}/{Denominator}";
        }

        // Метод для сокращения дроби
        private void Simplify()
        {
            // Нахождение наибольшего общего делителя (НОД)
            int gcd = GCD(Numerator, Denominator);

            // Сокращение числителя и знаменателя
            Numerator /= gcd;
            Denominator /= gcd;

            // Сброс кэшированного вещественного значения
            cachedRealValue = null;
        }

        // Метод для нахождения наибольшего общего делителя (НОД)
        private int GCD(int a, int b)
        {
            // Алгоритм Евклида для нахождения НОД
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return Math.Abs(a);
        }

        // Перегрузка оператора сложения для дробей
        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            int newNumerator = f1.Numerator * f2.Denominator + f2.Numerator * f1.Denominator;
            int newDenominator = f1.Denominator * f2.Denominator;
            return new Fraction(newNumerator, newDenominator);
        }

        // Перегрузка оператора вычитания для дробей
        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            int newNumerator = f1.Numerator * f2.Denominator - f2.Numerator * f1.Denominator;
            int newDenominator = f1.Denominator * f2.Denominator;
            return new Fraction(newNumerator, newDenominator);
        }

        // Перегрузка оператора умножения для дробей
        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            int newNumerator = f1.Numerator * f2.Numerator;
            int newDenominator = f1.Denominator * f2.Denominator;
            return new Fraction(newNumerator, newDenominator);
        }

        // Перегрузка оператора деления для дробей
        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            // Проверка на деление на ноль
            if (f2.Numerator == 0)
            {
                throw new DivideByZeroException("Деление на ноль.");
            }

            int newNumerator = f1.Numerator * f2.Denominator;
            int newDenominator = f1.Denominator * f2.Numerator;
            return new Fraction(newNumerator, newDenominator);
        }

        // Перегрузка оператора сложения дроби с целым числом
        public static Fraction operator +(Fraction f, int n)
        {
            return f + new Fraction(n, 1);
        }

        // Перегрузка оператора вычитания дроби с целым числом
        public static Fraction operator -(Fraction f, int n)
        {
            return f - new Fraction(n, 1);
        }

        // Перегрузка оператора умножения дроби на целое число
        public static Fraction operator *(Fraction f, int n)
        {
            return f * new Fraction(n, 1);
        }

        // Перегрузка оператора деления дроби на целое число
        public static Fraction operator /(Fraction f, int n)
        {
            // Проверка на деление на ноль
            if (n == 0)
            {
                throw new DivideByZeroException("Деление на ноль.");
            }
            return f / new Fraction(n, 1);
        }

        // Переопределение метода Equals для сравнения дробей
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Fraction other = (Fraction)obj;
            return Numerator == other.Numerator && Denominator == other.Denominator;
        }

        // Переопределение метода GetHashCode для получения хэш-кода дроби
        public override int GetHashCode()
        {
            return HashCode.Combine(Numerator, Denominator);
        }

        // Реализация метода Clone из интерфейса ICloneable
        public object Clone()
        {
            return new Fraction(Numerator, Denominator);
        }

        // Реализация метода GetRealValue из интерфейса IFraction
        public double GetRealValue()
        {
            // Если кэшированное значение отсутствует, вычисляем его
            if (cachedRealValue == null)
            {
                cachedRealValue = (double)Numerator / Denominator;
            }
            return cachedRealValue.Value;
        }

        // Реализация метода SetNumerator из интерфейса IFraction
        public void SetNumerator(int numerator)
        {
            Numerator = numerator;
            Simplify();
        }

        // Реализация метода SetDenominator из интерфейса IFraction
        public void SetDenominator(int denominator)
        {
            // Проверка на ноль в знаменателе
            if (denominator == 0)
            {
                throw new ArgumentException("Знаменатель не может быть равен нулю.");
            }
            Denominator = denominator;
            Simplify();
        }
    }
}
