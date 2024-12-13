using System;

namespace Lab_6
{
    // Класс-обертка для отслеживания количества мяуканий
    public class MeowCounter : IMeowable
    {
        private readonly IMeowable meowowable;
        public int MeowCount { get; private set; }

        public MeowCounter(IMeowable meowable)
        {
            meowowable = meowable;
            MeowCount = 0;
        }

        public void Meow()
        {
            meowowable.Meow();
            MeowCount++;
        }

        public void Meow(int times)
        {
            meowowable.Meow(times);
            MeowCount += times;
        }
    }
}
