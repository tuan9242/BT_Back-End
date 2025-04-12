using System;

class EvenOddChecker
{
    static void Main()
    {
        Console.WriteLine("KIEM TRA SO CHAN/LE");
        Console.Write("Nhap so nguyen: ");

        int number;
        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.Write("Vui long nhap 1 so nguyen hop le!: ");
        }

        if (number % 2 == 0)
            Console.WriteLine($"{number} La so chan");
        else
            Console.WriteLine($"{number} La so le");
    }
}