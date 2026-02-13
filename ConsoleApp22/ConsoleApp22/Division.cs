using System;
internal class Division
{
    public int first;
    public int second;

    public void Read()
    {

        while (true)
        {
            Console.Write("Введите числитель (положительное число): ");
            if (int.TryParse(Console.ReadLine(), out first) && first > 0)
                break;
            Console.WriteLine("Некорректный ввод! Введите положительное целое число.");
        }

        while (true)
        {
            Console.Write("Введите знаменатель (положительное число, не ноль): ");
            if (int.TryParse(Console.ReadLine(), out second) && second > 0)
                break;
            Console.WriteLine(second == 0 ?
                "Знаменатель не может быть нулем!" :
                "Некорректный ввод! Введите положительное целое число.");
        }

    }

    public int Ipart()
    {
        return first / second;
    }
    public void Display()
    {
        Console.WriteLine($"Целая часть: {Ipart()}");
    }
}