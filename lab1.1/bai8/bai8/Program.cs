using System;

class MultiplicationTable
{
    static void Main()
    {
        Console.WriteLine("bang cuu chuong tu 1 - 10:");

        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"\nBang nhan {i}:");
            for (int j = 1; j <= 10; j++)
            {
                Console.WriteLine($"{i} x {j} = {i * j}");
            }
        }
    }
}