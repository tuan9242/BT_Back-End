// Bài 22: Nhập danh sách n học sinh viết dưới dạng các thuộc tính: họ tên, năm sinh và tổngđiểm.
// Sắp xếp theo thứ tự giảm dần của tổng điểm.
// Khi tổng điểm như nhau thì học sinh có năm sinh nhỏ hơn được đứng trước.
// In ra danh sách học sinh đã sắp xếp sao cho tất cả các chữ cái đầu của họ tên chuyển thành chữ hoa


using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

class HocSinh
{
    public string HoTen;
    public int NamSinh;
    public double TongDiem;

    public HocSinh(string hoTen, int namSinh, double tongDiem)
    {
        HoTen = hoTen;
        NamSinh = namSinh;
        TongDiem = tongDiem;
    }

    public void InThongTin()
    {
        Console.WriteLine($"Ho tên: {ChuanHoaHoTen(HoTen)}");
        Console.WriteLine($"Năm sinh: {NamSinh}");
        Console.WriteLine($"Tong điem: {TongDiem}");
        Console.WriteLine("------------------------------");
    }

    public static string ChuanHoaHoTen(string ten)
    {
        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(
            ten.Trim().ToLower()
        );
    }
}

class Program
{
    static void Main()
    {
        List<HocSinh> danhSach = new List<HocSinh>();

        Console.Write("Nhap so lưong hoc sinh: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\n--- Nhap hoc sinh thu {i + 1} ---");

            Console.Write("Ho tên: ");
            string hoTen = Console.ReadLine();

            Console.Write("Năm sinh: ");
            int namSinh = int.Parse(Console.ReadLine());

            Console.Write("Tong điem: ");
            double tongDiem = double.Parse(Console.ReadLine());

            danhSach.Add(new HocSinh(hoTen, namSinh, tongDiem));
        }

        danhSach.Sort((a, b) =>
        {
            int cmpDiem = b.TongDiem.CompareTo(a.TongDiem);
            if (cmpDiem == 0)
                return a.NamSinh.CompareTo(b.NamSinh); 
            return cmpDiem;
        });

        Console.WriteLine("\n=== Danh sach học sinh sau khi sap xep ===");
        foreach (var hs in danhSach)
        {
            hs.InThongTin();
        }
    }
}
