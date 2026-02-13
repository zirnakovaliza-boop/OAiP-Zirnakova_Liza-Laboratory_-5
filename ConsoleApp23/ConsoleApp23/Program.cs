using System;
    class Program
    {
        static void Main()
        {
            Money m1 = new Money(1234.75m);
            Money m2 = new Money(88.50m);

            Console.WriteLine("m1: " + m1);
            Console.WriteLine("m2: " + m2);

            Money sum = m1 + m2;
            Console.WriteLine("Сумма: " + sum);

            Money diff = m1 - m2;
            Console.WriteLine("Разность: " + diff);

            Console.WriteLine($"m1 * 1.5 = {m1 * 1.5m}");
            Console.WriteLine($"m1 / 2   = {m1 / 2m}");
            Console.WriteLine($"m1 > m2  = {m1 > m2}");
        }
    }
