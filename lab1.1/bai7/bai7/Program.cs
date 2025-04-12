using System;

class LeapYearChecker
{
    static void Main()
    {
        Console.WriteLine("KIEM TRA NAM NHUAN");
        Console.Write("NHAP SO NAM : ");

        int year;
        while (!int.TryParse(Console.ReadLine(), out year) || year <= 0)
        {
            Console.Write("VUI LONG NHAP SO NAM HOP LE (SO NGUYEN DUONG): ");
        }

        bool isLeap = (year % 400 == 0) || (year % 4 == 0 && year % 100 != 0);

        Console.WriteLine(isLeap ? $"{year} LA NAM NHUAN" : $"{year} KHONG PHAI NAM NHUAN");
    }
}