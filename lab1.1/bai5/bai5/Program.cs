using System;

class SumAndProduct
{
    static void Main()
    {
        Console.WriteLine("TINH TONG VA TICH 2 SO");

        Console.Write("Nhap so thu nhat: ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Nhap so thu hai: ");
        double num2 = Convert.ToDouble(Console.ReadLine());

        double sum = num1 + num2;
        double product = num1 * num2;

        Console.WriteLine($"Tong: {num1} + {num2} = {sum}");
        Console.WriteLine($"Tich: {num1} × {num2} = {product}");
    }
}