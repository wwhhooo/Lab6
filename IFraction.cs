using System;

namespace Lab_6
{
    // Интерфейс для работы с дробями
    public interface IFraction
    {
        // Метод для получения вещественного значения дроби
        double GetRealValue();

        // Метод для установки числителя
        void SetNumerator(int numerator);

        // Метод для установки знаменателя
        void SetDenominator(int denominator);
    }
}
