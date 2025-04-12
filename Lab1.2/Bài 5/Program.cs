// Bài 5: Viết hàm hoán vị 2 số nguyên a và b nhập từ bàn phím.

using System;
static int FindSecondLargest(int[] numbers)
{
    if (numbers.Length < 2)
    {
        throw new ArgumentException("Mảng phải có ít nhất hai phần tử.");
    }

int largest = int.MinValue;
int secondLargest = int.MinValue;

foreach (int num in numbers)
{
        if (num > largest)
        {
            secondLargest = largest;
            largest = num;
        }
        else if (num > secondLargest && num < largest)
        {
            secondLargest = num;
        }
}
    if (secondLargest == int.MinValue)
    {
        throw new ArgumentException("Không tim thay so lon thu ha.");
    }
    return secondLargest;
}
static void Swap(ref int a, ref int b)
{
    int temp = a;
    a = b;
    b = temp;
}

Console.Write("Nhap so phan tu cua mang: ");
int n = int.Parse(Console.ReadLine());
int[] array = new int[n];

for (int i = 0; i < n; i++)
{
    Console.Write($"Nhap phan tu thu {i + 1}: ");
    array[i] = int.Parse(Console.ReadLine());
}

try
{
    int secondLargest = FindSecondLargest(array);
    Console.WriteLine($"So lon thu hai trong mang la: {secondLargest}");
}
catch (ArgumentException e)
{
    Console.WriteLine(e.Message);
}
    Console.Write("Nhap so nguyên a: ");
    int a = int.Parse(Console.ReadLine());
    Console.Write("Nhap so nguyên b: ");
    int b = int.Parse(Console.ReadLine());

Swap(ref a, ref b);
Console.WriteLine($"Sau khi hoan vi: a = {a}, b = {b}");

