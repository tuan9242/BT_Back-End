// Bài 3: Viết một hàm để đếm số lượng số âm và số dương trong một mảng gồm n phần tử nhập từ bàn phím.

using System;
static void CountPositiveNegative(int[] numbers, out int positiveCount, out int negativeCount)
{
    positiveCount = 0;
    negativeCount = 0;
    
    foreach (int num in numbers)
    {
        if (num > 0)
            positiveCount++;
        else if (num < 0)
            negativeCount++;
    }
}

 Console.Write("Nhap so phan tu cua mang: ");
int n = int.Parse(Console.ReadLine());
int[] array = new int[n];

for (int i = 0; i < n; i++)
{
    Console.Write($"Nhap phan thu thu {i + 1}: ");
    array[i] = int.Parse(Console.ReadLine());
}

CountPositiveNegative(array, out int positiveCount, out int negativeCount);

Console.WriteLine($"So lưong so dương: {positiveCount}");
Console.WriteLine($"So lưong so âm: {negativeCount}");
