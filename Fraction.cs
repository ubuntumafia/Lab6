using System;

namespace Lab6
{
    public class Fraction : ICloneable, IFractionOperations
    {
        private int numerator;   // Числитель
        private int denominator; // Знаменатель
        private FractionCache cache = new FractionCache();

        // Конструктор
        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Знаменатель не может быть нулем.");
            }

            // Убираем отрицательный знак из знаменателя
            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }

            this.numerator = numerator;
            this.denominator = denominator;

            Reduce();
        }

        public override string ToString()
        {
            return $"{numerator}/{denominator}";
        }

        private void Reduce()
        {
            int nod = NOD(Math.Abs(numerator), Math.Abs(denominator));
            numerator /= nod;
            denominator /= nod;
        }

        private int NOD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public object Clone()
        {
            return new Fraction(this.numerator, this.denominator);
        }

        public Fraction Sum(Fraction other)
        {
            int newNumerator = this.numerator * other.denominator + other.numerator * this.denominator;
            int newDenominator = this.denominator * other.denominator;
            return new Fraction(newNumerator, newDenominator);
        }

        public Fraction Minus(Fraction other)
        {
            int newNumerator = this.numerator * other.denominator - other.numerator * this.denominator;
            int newDenominator = this.denominator * other.denominator;
            return new Fraction(newNumerator, newDenominator);
        }

        public Fraction Multiply(Fraction other)
        {
            return new Fraction(this.numerator * other.numerator, this.denominator * other.denominator);
        }

        public Fraction Div(Fraction other)
        {
            if (other.numerator == 0)
            {
                throw new ArgumentException("Деление на ноль невозможно.");
            }
            return new Fraction(this.numerator * other.denominator, this.denominator * other.numerator);
        }

        // Перегрузка оператора вычитания с целым числом
        public Fraction Minus(int integer)
        {
            return new Fraction(this.numerator - integer * this.denominator, this.denominator);
        }

        // Переопределение метода Equals
        public override bool Equals(object obj)
        {
            if (obj is Fraction other)
            {
                return this.numerator == other.numerator && this.denominator == other.denominator;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(numerator, denominator);
        }

        public double GetDecimalValue()
        {
            return cache.GetCachedValue(numerator, denominator); // Получаем кэшированное значение
        }

        // Метод для установки числителя
        public void SetNumerator(int numerator)
        {
            this.numerator = numerator;
            cache.InvalidateCache(); // Сбрасываем кэш
            Reduce();
        }

        // Метод для установки знаменателя
        public void SetDenominator(int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Знаменатель не может быть нулем.");
            }

            this.denominator = denominator;
            cache.InvalidateCache(); // Сбрасываем кэш
            Reduce();
        }

        public static Fraction ReadFraction(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                var parts = input.Split('/');

                if (parts.Length == 2 &&
                    int.TryParse(parts[0], out int numerator) &&
                    int.TryParse(parts[1], out int denominator) && denominator != 0)
                {
                    return new Fraction(numerator, denominator);
                }
                else
                {
                    Console.WriteLine("Некорректный ввод дроби. Пожалуйста, введите в формате числитель/знаменатель.");
                }
            }
        }
    }
}
