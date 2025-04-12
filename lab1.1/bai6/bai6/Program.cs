using System;

class NumberSignChecker
{
    static void Main()
    {
        Console.WriteLine("KIEM TRA SO AM HAY DUONG");
        Console.Write("Nhap 1 so: ");

        double number;
        while (!double.TryParse(Console.ReadLine(), out number))
        {
            Console.Write("Vui long nhap so hop le!: ");
        }

        if (number > 0)
            Console.WriteLine($"{number} La so duong");
        else if (number < 0)
            Console.WriteLine($"{number} La so am");
        else
            Console.WriteLine("Day la so 0");
    }
}