// Bài 2: Viết chương trình nhập vào mảng gồm n phần tử nhập từ bàn phím.
// Viết hàm để kiểm tra xem một số có phải là số nguyên tố hay không
// hiển thị chỉ số và giá trị của những phần tử là số nguyên tố trong mảng.

using System;
static bool IsPrime(int number)
{
    if (number < 2)
        return false;
    for (int i = 2; i * i <= number; i++)
    {
        if (number % i == 0)
            return false;
    }
    return true;
}

Console.Write("Nhap so phan tu cua mang: ");
int n = int.Parse(Console.ReadLine());
int[] array = new int[n];

for (int i = 0; i < n; i++)
{
    Console.Write($"Nhap phan tu thu {i + 1}: ");
    array[i] = int.Parse(Console.ReadLine());
}

Console.WriteLine("Cac phan tu la so nguyên to trong mang.");
for (int i = 0; i < n; i++)
{
    if (IsPrime(array[i]))
    {
        Console.WriteLine($"Chi so: {i}, Gia tri: {array[i]}");
    }
}
