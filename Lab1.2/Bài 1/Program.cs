// Bài 1: Viết một hàm để tính tổng của tất cả các số chẵn trong một mảng.

using System;
static int SumEvenNumbers(int[] numbers)
{
    int sum = 0;
    foreach (int num in numbers)
    {
        if (num % 2 == 0)
        {
            sum += num;
        }
    }
    return sum;
}
int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
Console.WriteLine("Tong cac so chan: " + SumEvenNumbers(array));
