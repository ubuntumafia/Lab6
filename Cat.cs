using Lab6;
using System;

public class Cat : IMeow
{
    private string Name { get; set; }

    public Cat(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return $"кот: {Name}";
    }

    public void Meow()
    {
        Console.WriteLine($"{Name}: мяу!");
    }

    public void Meow(int n)
    {
        if (n <= 0)
        {
            Console.WriteLine("Количество мяу должно быть больше нуля.");
            return;
        }

        Console.Write($"{Name}: ");
        for (int i = 0; i < n; i++)
        {
            if (i == n - 1)
            {
                Console.Write("мяу!");
            }
            else
            {
                Console.Write("мяу");
                Console.Write("-");
            }
        }
        Console.WriteLine();
    }
}
