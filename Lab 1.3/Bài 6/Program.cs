// Bài 6: Để quản lý hồ sơ học sinh của trường THPT, người ta cần quản lý những thông tin như sau:
//          -Các thông tin về : lớp, khoá học, kỳ học, và các thông tin cá nhân của mỗi học sinh.
//          - Với mỗi học sinh, các thông tin cá nhân cần quản lý gồm có: Họ và tên, tuổi, năm sinh, quê quán, giới tính.
//      1. Hãy xây dựng lớp Nguoi để quản lý các thông tin cá nhân của mỗi học sinh.
//      2. Xây dựng lớp HSHocSinh (hồ sơ học sinh) để lý các thông tin về mỗi học sinh.
//      3. Xây dựng các phương thức : nhập, hiển thị các thông tin về hồ sơ cá nhân của mỗi học sinh.
//      4. Cài đặt chương trình thực hiện các công việc sau:
//          -Nhập vào một danh sách gồm n học sinh ( n- nhập từ bàn phím)
//          - Hiển thị ra màn hình tất cả những học sinh nữ và sinh năm 1985.
//          - Tìm kiếm học sinh theo quê quán.
//          - Thoát khỏi chương trình

using System;
using System.Collections.Generic;
class Nguoi
{
    public string HoTen { get; set; }
    public int Tuoi { get; set; }
    public int NamSinh { get; set; }
    public string QueQuan { get; set; }
    public string GioiTinh { get; set; }

    public void NhapThongTin()
    {
        Console.Write("Ho tên: ");
        HoTen = Console.ReadLine();
        Console.Write("Tuoi: ");
        Tuoi = int.Parse(Console.ReadLine());
        Console.Write("Năm sinh: ");
        NamSinh = int.Parse(Console.ReadLine());
        Console.Write("Quê quan: ");
        QueQuan = Console.ReadLine();
        Console.Write("Gioi tinh (Nam/Nu): ");
        GioiTinh = Console.ReadLine();
    }

    public void HienThiThongTin()
    {
        Console.WriteLine($"Ho tên: {HoTen}, Tuoi: {Tuoi}, Năm sinh: {NamSinh}, Quê quan: {QueQuan}, Gioi tinh: {GioiTinh}");
    }
}

class HSHocSinh
{
    public Nguoi HocSinh { get; set; }
    public string Lop { get; set; }
    public string KhoaHoc { get; set; }
    public string KyHoc { get; set; }

    public void NhapThongTin()
    {
        HocSinh = new Nguoi();
        HocSinh.NhapThongTin();
        Console.Write("Lop: ");
        Lop = Console.ReadLine();
        Console.Write("Khoa hoc: ");
        KhoaHoc = Console.ReadLine();
        Console.Write("Ky hoc: ");
        KyHoc = Console.ReadLine();
    }

    public void HienThiThongTin()
    {
        HocSinh.HienThiThongTin();
        Console.WriteLine($"Lop: {Lop}, Khoa hoc: {KhoaHoc}, Ky hoc: {KyHoc}");
    }
}

class TruongHoc
{
    private List<HSHocSinh> danhSachHocSinh = new List<HSHocSinh>();

    public void NhapDanhSachHocSinh()
    {
        Console.Write("Nhap so hoc sinh: ");
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Nhap thông tin cho học sinh {i + 1}:");
            HSHocSinh hs = new HSHocSinh();
            hs.NhapThongTin();
            danhSachHocSinh.Add(hs);
        }
    }

    public void HienThiHocSinhNuNam1985()
    {
        foreach (var hs in danhSachHocSinh)
        {
            if (hs.HocSinh.GioiTinh.ToLower() == "nu" && hs.HocSinh.NamSinh == 1985)
            {
                hs.HienThiThongTin();
                Console.WriteLine("--------------------");
            }
        }
    }

    public void TimKiemHocSinhTheoQueQuan()
    {
        Console.Write("Nhap quê quan can tim: ");
        string queQuan = Console.ReadLine();
        foreach (var hs in danhSachHocSinh)
        {
            if (hs.HocSinh.QueQuan.Equals(queQuan, StringComparison.OrdinalIgnoreCase))
            {
                hs.HienThiThongTin();
                Console.WriteLine("--------------------");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        TruongHoc truongHoc = new TruongHoc();
        while (true)
        {
            Console.WriteLine("Chon chuc năng: 1. Nhap hoc sinh | 2. Hien thi HS nu sinh năm 1985 | 3. Tim theo quê quan | 4. Thoat");
            int chon = int.Parse(Console.ReadLine());
            switch (chon)
            {
                case 1:
                    truongHoc.NhapDanhSachHocSinh();
                    break;
                case 2:
                    truongHoc.HienThiHocSinhNuNam1985();
                    break;
                case 3:
                    truongHoc.TimKiemHocSinhTheoQueQuan();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Lua chon không hop le!");
                    break;
            }
        }
    }
}
