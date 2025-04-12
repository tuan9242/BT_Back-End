using System;

class FactorialCalculator
{
    static void Main()
    {
        Console.WriteLine("tinh giai thua ");
        Console.Write("Nhap so nguyen duong: ");

        int n;
        while (!int.TryParse(Console.ReadLine(), out n) || n < 0)
        {
            Console.Write("Vui long khong nhap so nguyen am!: ");
        }

        long factorial = 1;
        for (int i = 2; i <= n; i++)
        {
            factorial *= i;
        }

        Console.WriteLine($"{n}! = {factorial}");
    }
}