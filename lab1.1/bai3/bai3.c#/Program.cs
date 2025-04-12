using System;

class TemperatureConverter
{
    static void Main(string[] args)
    {
        Console.WriteLine("chuong trinh chuyen doi nhiet do: ");
        Console.WriteLine("Tu đo C sang đo F");

        // Nhập nhiệt độ Celsius
        Console.Write("Nhap nhiet đo (đo C): ");
        double celsius = Convert.ToDouble(Console.ReadLine());

        // Chuyển đổi sang Fahrenheit
        double fahrenheit = (celsius * 9 / 5) + 32;

        // Hiển thị kết quả
        Console.WriteLine($"{celsius}°C = {fahrenheit}°F");

        Console.ReadKey(); // Dừng màn hình để xem kết quả
    }
}