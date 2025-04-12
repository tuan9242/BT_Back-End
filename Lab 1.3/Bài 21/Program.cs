// Bài 21: Một trường trung học, học sinh bắt buộc phải học 3 môn toán, lý, hoá. Ngoài ra học sinh nam học thêm môn kĩ thuật, học sinh nữ học thêm môn nữ công. Viết chương trình để:
//1.Nhập họ tên, giới tính và điểm của n học sinh;
//2.Hiển thị thông tin về những học sinh nam có điểm môn kĩ thuật không nhỏ hơn 8.
//3. In số liệu về học sinh nam trước rồi đến các học sinh nữ

using System;
using System.Collections.Generic;

class HocSinh
{
    public string HoTen;
    public string GioiTinh;
    public double Toan;
    public double Ly;
    public double Hoa;

    public HocSinh(string hoTen, string gioiTinh, double toan, double ly, double hoa)
    {
        HoTen = hoTen;
        GioiTinh = gioiTinh.ToLower();
        Toan = toan;
        Ly = ly;
        Hoa = hoa;
    }

    public virtual void InThongTin()
    {
        Console.WriteLine($"Ho tên: {HoTen}");
        Console.WriteLine($"Gioi tinh: {GioiTinh}");
        Console.WriteLine($"Toan: {Toan}, Ly: {Ly}, Hoa: {Hoa}");
    }

    public bool LaNam => GioiTinh == "nam";
    public bool LaNu => GioiTinh == "nu";
}

class HocSinhNam : HocSinh
{
    public double KyThuat;

    public HocSinhNam(string hoTen, double toan, double ly, double hoa, double kyThuat)
        : base(hoTen, "nam", toan, ly, hoa)
    {
        KyThuat = kyThuat;
    }

    public override void InThongTin()
    {
        base.InThongTin();
        Console.WriteLine($"Ky thuat: {KyThuat}");
    }
}

class HocSinhNu : HocSinh
{
    public double NuCong;

    public HocSinhNu(string hoTen, double toan, double ly, double hoa, double nuCong)
        : base(hoTen, "nu", toan, ly, hoa)
    {
        NuCong = nuCong;
    }

    public override void InThongTin()
    {
        base.InThongTin();
        Console.WriteLine($"Nu công: {NuCong}");
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
            Console.WriteLine($"\n--- Nhap học sinh thu {i + 1} ---");
            Console.Write("Ho tên: ");
            string hoTen = Console.ReadLine();

            Console.Write("Gioi tinh (nam/nu): ");
            string gioiTinh = Console.ReadLine().ToLower();

            Console.Write("Điem Toan: ");
            double toan = double.Parse(Console.ReadLine());

            Console.Write("Điem Ly: ");
            double ly = double.Parse(Console.ReadLine());

            Console.Write("Điem Hoa: ");
            double hoa = double.Parse(Console.ReadLine());

            if (gioiTinh == "nam")
            {
                Console.Write("Điem Ky thuat: ");
                double kyThuat = double.Parse(Console.ReadLine());
                danhSach.Add(new HocSinhNam(hoTen, toan, ly, hoa, kyThuat));
            }
            else if (gioiTinh == "nu")
            {
                Console.Write("Điem Nu công: ");
                double nuCong = double.Parse(Console.ReadLine());
                danhSach.Add(new HocSinhNu(hoTen, toan, ly, hoa, nuCong));
            }
            else
            {
                Console.WriteLine("Gioi tinh không hop le. Bo qua hoc sinh nay.");
            }
        }

        Console.WriteLine("\n=== Hoc sinh nam có điem ky thuat >= 8 ===");
        foreach (var hs in danhSach)
        {
            if (hs is HocSinhNam hsNam && hsNam.KyThuat >= 8)
            {
                hsNam.InThongTin();
                Console.WriteLine("----------------------");
            }
        }

        Console.WriteLine("\n=== Danh sach học sinh: Nam trưoc, Nu sau ===");

        Console.WriteLine("\n--- Hoc sinh Nam ---");
        foreach (var hs in danhSach)
        {
            if (hs.LaNam)
            {
                hs.InThongTin();
                Console.WriteLine("----------------------");
            }
        }

        Console.WriteLine("\n--- Hoc sinh Nu ---");
        foreach (var hs in danhSach)
        {
            if (hs.LaNu)
            {
                hs.InThongTin();
                Console.WriteLine("----------------------");
            }
        }
    }
}
