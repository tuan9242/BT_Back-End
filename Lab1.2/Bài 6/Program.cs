// Bài 6: Viết hàm sắp xếp mảng số thực n phần tử nhập từ bàn phím theo chiều tăng dần.

using System;

Console.Write("Nhap so phan tu cua mang: ");
int n = int.Parse(Console.ReadLine());

double[] arr = new double[n];
for (int i = 0; i < n; i++)
{
    Console.Write($"Nhap phan tu thu {i + 1}: ");
    arr[i] = double.Parse(Console.ReadLine());
}

Array.Sort(arr); 

Console.WriteLine("Mang sau khi sap xep tăng dan:");
foreach (double num in arr)
{
     Console.Write(num + " ");
}