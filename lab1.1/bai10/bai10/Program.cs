using System;

class PrimeNumberChecker
{
    static void Main()
    {
        Console.WriteLine("KIEM TRA SO NGUYEN TO");
        Console.Write("nhap 1 so nguyen duong: ");

        int number;
        while (!int.TryParse(Console.ReadLine(), out number) || number <= 1)
        {
            Console.Write("Vui long nhap so lon hon 1: ");
        }

        bool isPrime = true;
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
            {
                isPrime = false;
                break;
            }
        }

        Console.WriteLine(isPrime ? $"{number} la so nguyen to " : $"{number} khong phai so nguyen to");
    }
}