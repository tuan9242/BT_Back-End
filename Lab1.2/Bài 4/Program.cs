// Bài 4: Viết hàm để tìm số lớn thứ hai trong một mảng các số nguyên.

using System;
static int FindSecondLargest(int[] numbers)
{
    if (numbers.Length < 2)
    {
        throw new ArgumentException("Mang phai co it nhat hai phan tu.");
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
    throw new ArgumentException("Khong tim thay so lon thu hai.");
}
    return secondLargest;
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

