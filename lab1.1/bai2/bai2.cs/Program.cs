using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("CHUONG TRINH TINH DIEN TICH HINH CHU NHAT");

        // Nhập chiều dài
        Console.Write("Nhap chieu dai: ");
        double chieuDai = Convert.ToDouble(Console.ReadLine());

        // Nhập chiều rộng
        Console.Write("Nhập chieu rong: ");
        double chieuRong = Convert.ToDouble(Console.ReadLine());

        // Tính diện tích
        double dienTich = chieuDai * chieuRong;

        // Hiển thị kết quả
        Console.WriteLine($"Dien tich hinh chu nhat la: {dienTich}");

        Console.ReadKey(); // Dừng màn hình để xem kết quả
    }
}