using Lab6;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Просто мяу");
            Console.WriteLine("2. Мяу разными голосами");
            Console.WriteLine("3. Посчитать мяу");
            Console.WriteLine("4. Задачи с дробями");
            Console.WriteLine("5. Сравнение дробей");
            Console.WriteLine("6. Клонирование дроби");
            Console.WriteLine("7. Кэширование дроби");
            Console.WriteLine("0. Выход");
            Console.Write("Введите номер действия: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Cat barsik = new Cat("Барсик");

                    barsik.Meow();

                    barsik.Meow(3);
                    break;

                case "2":
                    Console.WriteLine("Введите имя первого кота: ");
                    string catName1;
                    while (string.IsNullOrWhiteSpace(catName1 = Console.ReadLine()))
                    {
                        Console.WriteLine("Имя не может быть пустым. Пожалуйста, введите имя снова.");
                    }
                    Cat pushistik = new Cat(catName1);

                    Console.WriteLine("Введите имя второго кота: ");
                    string catName2;
                    while (string.IsNullOrWhiteSpace(catName2 = Console.ReadLine()))
                    {
                        Console.WriteLine("Имя не может быть пустым. Пожалуйста, введите имя снова.");
                    }
                    Cat murka = new Cat(catName2);

                    Console.WriteLine("Введите имя третьего кота: ");
                    string catName3;
                    while (string.IsNullOrWhiteSpace(catName3 = Console.ReadLine()))
                    {
                        Console.WriteLine("Имя не может быть пустым. Пожалуйста, введите имя снова.");
                    }
                    Cat matros = new Cat(catName3);

                    IMeow[] cats = new IMeow[] { pushistik, murka, matros };

                    MeowMaker.MakeThemMeow(cats);
                    break;

                case "3":
                    Console.Write("Введите имя кота: ");
                    string catName = Console.ReadLine();
                    while (string.IsNullOrWhiteSpace(catName = Console.ReadLine()))
                    {
                        Console.WriteLine("Имя не может быть пустым. Пожалуйста, введите имя снова.");
                    }

                    Cat kotik = new Cat(catName);

                    Console.Write("Введите количество мяуканий: ");
                    if (int.TryParse(Console.ReadLine(), out int meowCount) && meowCount > 0)
                    {
                        MeowCounter meowCounter = new MeowCounter(kotik);
                        meowCounter.Meow(meowCount);

                        int count = meowCounter.GetMeowCount();
                        Console.WriteLine($"Количество мяуканий: {count}");
                    }
                    else
                    {
                        Console.WriteLine("Некорректное количество мяуканий. Пожалуйста, введите положительное число.");
                    }
                    break;

                case "4":
                    Fraction f1 = Fraction.ReadFraction("Введите первую дробь (числитель/знаменатель): ");
                    Fraction f2 = Fraction.ReadFraction("Введите вторую дробь (числитель/знаменатель): ");
                    Fraction f3 = Fraction.ReadFraction("Введите третью дробь (числитель/знаменатель): ");

                    Fraction result1 = f1.Multiply(f2);
                    Console.WriteLine($"{f1} * {f2} = {result1}");

                    Fraction result2 = f1.Sum(f2);
                    Console.WriteLine($"{f1} + {f2} = {result2}");

                    Fraction result3 = f1.Minus(f2);
                    Console.WriteLine($"{f1} - {f2} = {result3}");

                    Fraction result4 = f1.Div(f2);
                    Console.WriteLine($"{f1} / {f2} = {result4}");

                    Fraction finalResult = f1.Sum(f2).Div(f3).Minus(5);
                    Console.WriteLine($"Результат: {finalResult}");
                    break;

                case "5":
                    Fraction f4 = Fraction.ReadFraction("Введите первую дробь (числитель/знаменатель): ");
                    Fraction f5 = Fraction.ReadFraction("Введите вторую дробь (числитель/знаменатель): ");

                    Console.WriteLine(f4.Equals(f5));
                    break;

                case "6":
                    Fraction original = Fraction.ReadFraction("Введите дробь для клонирования (числитель/знаменатель): ");
                    Fraction clone = (Fraction)original.Clone();

                    Console.WriteLine($"Оригинал: {original}");
                    Console.WriteLine($"Клон: {clone}");
                    break;

                case "7":
                    Fraction fraction = Fraction.ReadFraction("Введите дробь (числитель/знаменатель): ");
                    Console.WriteLine($"Дробь: {fraction}");
                    Console.WriteLine($"Вещественное значение: {fraction.GetDecimalValue()}");

                    Console.Write("Введите новый числитель: ");
                    if (int.TryParse(Console.ReadLine(), out int newNumerator))
                    {
                        fraction.SetNumerator(newNumerator);
                        Console.WriteLine($"Обновленная дробь: {fraction}");
                        Console.WriteLine($"Вещественное значение: {fraction.GetDecimalValue()}");
                    }

                    Console.Write("Введите новый знаменатель: ");
                    if (int.TryParse(Console.ReadLine(), out int newDenominator) && newDenominator != 0)
                    {
                        fraction.SetDenominator(newDenominator);
                        Console.WriteLine($"Обновленная дробь: {fraction}");
                        Console.WriteLine($"Вещественное значение: {fraction.GetDecimalValue()}");
                    }
                    else
                    {
                        Console.WriteLine("Некорректный знаменатель. Знаменатель не может быть нулем.");
                    }
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Неверный выбор. Пожалуйста, попробуйте снова.");
                    break;
            }
        }
    }
}
