using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_6
{
    class Program
    {
        // Метод для вызова мяуканья у объектов
        static void MeowMachine(IEnumerable<IMeowable> meowables)
        {
            foreach (var meowable in meowables)
            {
                meowable.Meow();
            }
        }

        static void Main(string[] args)
        {
            // Создаем котов
            Cat Barsik = new Cat("Барсик");
            Cat Masha = new Cat("Маша");
            Cat Roma = new Cat("Рома");

            // Создаем зомби-котика
            ZomboCat ZomboCat = new ZomboCat("Zombokitty");

            // Создаем объекты чтобы считать мяуканья
            MeowCounter BarsikCounter = new MeowCounter(Barsik);
            MeowCounter MashaCounter = new MeowCounter(Masha);
            MeowCounter RomaCounter = new MeowCounter(Roma);
            MeowCounter ZombokittyCounter = new MeowCounter(ZomboCat);

            // Создаем список из мяукающих объектов
            List<IMeowable> meowables = new List<IMeowable> { BarsikCounter, MashaCounter, RomaCounter, ZombokittyCounter };
            
            Console.WriteLine("^_^ Котята разговривают ^_^");
            
            Console.WriteLine("^_^ Мяукает Барсик ^_^");
            // Вызываем мяуканье у Барсика
            BarsikCounter.Meow(1);
            // Вызываем мяуканье у Барсика еще три раза
            BarsikCounter.Meow(3);
            
            Console.WriteLine("^_^ Теперь все вместе ^_^");
            // Подвергаем все объекты мяукающей напасти
            MeowMachine(meowables);

            Console.WriteLine();
            Console.WriteLine("^_^ Поговорили, считаем ^_^");
            Console.WriteLine();

            // Выводим количество мяуканий для каждого объекта
            Console.WriteLine($"Барсик мяукал {BarsikCounter.MeowCount} раз");
            Console.WriteLine($"Маша мяукала {MashaCounter.MeowCount} раз");
            Console.WriteLine($"Рома мяукал {RomaCounter.MeowCount} раз");
            Console.WriteLine($"Zombokitty мяукал {ZombokittyCounter.MeowCount} раз");
            
            Console.WriteLine();
            Console.WriteLine("--Котята кончились, начались дроби--");
            Console.WriteLine();

            // Создаем несколько экземпляров дробей
            Fraction f1 = new Fraction(1, 3);
            Fraction f2 = new Fraction(2, 3);
            Fraction f3 = new Fraction(2, 9);

            // Примеры использования методов
            Fraction summ = f1 + f2;
            Fraction diff = f1 - f2;
            Fraction mult = f1 * f2;
            Fraction div = f1 / f2;

            // Выводим примеры и результаты их выполнения
            Console.WriteLine("---Пару примеров с базовыми арифметическими операциями над дробями---");
            Console.WriteLine($"{f1} + {f2} = {summ}");
            Console.WriteLine($"{f1} - {f2} = {diff}");
            Console.WriteLine($"{f1} * {f2} = {mult}");
            Console.WriteLine($"{f1} / {f2} = {div}");

            // Примеры операций с целыми числами
            Fraction summInt = f1 + 5;
            Fraction diffInt = f1 - 5;
            Fraction multInt = f1 * 5;
            Fraction divInt = f1 / 5;
            
            // Выводим примеры и результаты их выполнения
            Console.WriteLine("---Примеры с целыми чисалми---");
            Console.WriteLine($"{f1} + 5 = {summInt}");
            Console.WriteLine($"{f1} - 5 = {diffInt}");
            Console.WriteLine($"{f1} * 5 = {multInt}");
            Console.WriteLine($"{f1} / 5 = {divInt}");
            
            // Вычисляем f1.summ(f2).div(f3).minus(5)
            Console.WriteLine("---Вычисляем f1.summ(f2).div(f3).minus(5)---");
            Fraction result = (f1 + f2) / f3 - 5;
            Console.WriteLine($"({f1} + {f2}) / {f3} - 5 = {result}");

            // Примеры сравнения дробей
            Console.WriteLine("---Примеры сравнения дробей---");
            Fraction f4 = new Fraction(2, 10);
            Fraction f5 = new Fraction(1, 5);
            Console.WriteLine($"{f4} == {f5} | Значение {f4.Equals(f5)}"); // Должно быть true
            Console.WriteLine($"{f1} == {f2} | Значение {f1.Equals(f2)}"); // Должно быть false

            // Примеры клонирования дробей
            Console.WriteLine("---Примеры клонирования дробей---");
            Fraction f6 = (Fraction)f1.Clone();
            Console.WriteLine($"Клон {f1} : {f6}");
            Console.WriteLine($"{f1} == {f6} | Значение {f1.Equals(f6)}"); // Должно быть true

            // Примеры получения десятичного значения
            Console.WriteLine("---Примеры получения десятичного значения---");
            Console.WriteLine($"Дробь: {f1} | Десятичный вид: {f1.GetRealValue()}");
            Console.WriteLine($"Дробь: {f2} | Десятичный вид: {f2.GetRealValue()}");


            // Пример установки числителя и знаменателя
            Console.WriteLine("---Пример установки числителя и знаменателя---");
            Console.Write($"Исходная дробь: {f1} | ");
            f1.SetNumerator(1);
            f1.SetDenominator(4);
            Console.WriteLine($"Обновленная дробь {f1} | Десятичный вид: {f1.GetRealValue()}");
        }
    }
}
