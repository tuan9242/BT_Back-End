// Bài 7: Khoa Công nghệ thông tin
// - Trường Đại Học Đại Nam cần quản lý việc thanh toán tiền lương cho các cán bộ giáo viên trong khoa.
//  Để quản lý được, thì nhà quản lý cần có những thông tin như sau:
//      -Với mỗi cán bộ giáo viên, có các thông tin chung như sau: lương cứng, thưởng, phạt, lương thực lĩnh và các thông tin cá nhân của mỗi cán bộ giáo viên
//      - Các thông tin cá nhân của mỗi cán bộ giáo viên: Họ và tên, năm sinh, quê quán, số chứng minh thư nhân dân.
//  1. Hãy xây dựng lớp Nguoi để quản lý các thông tin cá nhân về mỗi cán bộ giáo viên
//  2. Xây dựng lớp CBGV (cán bộ giáo viên) để quản lý các thông tin chung về mỗi cán bộ giáo viên
//  3. Xây dựng các phương thức: nhập, hiển thị các thông tin cá nhân của mỗi cán bộ giáo viên
//  4. Tính lương thực lĩnh cho mỗi cán bộ nếu công thức tính lương được tính như sau: Lương thực lĩnh=Lương cứng + thưởng - phạt
//  5. Nhập vào một danh sách các cán bộ giáo viên, thực hiện các công việc sau:
//      -Tìm kiếm thông tin về cán bộ giáo viên theo quê quán;
//      -Hiển thị thông tin về các cán bộ giáo viên có lương thực lĩnh trên 5 triệu đồng một tháng.
//      - Thoát khỏi chương trình.

using System;
using System.Collections.Generic;
class Nguoi
{
    public string HoTen { get; set; }
    public int NamSinh { get; set; }
    public string QueQuan { get; set; }
    public string SoCMND { get; set; }

    public void NhapThongTin()
    {
        Console.Write("Ho tên: ");
        HoTen = Console.ReadLine();
        Console.Write("Năm sinh: ");
        NamSinh = int.Parse(Console.ReadLine());
        Console.Write("Quê quan: ");
        QueQuan = Console.ReadLine();
        Console.Write("So CMND: ");
        SoCMND = Console.ReadLine();
    }

    public void HienThiThongTin()
    {
        Console.WriteLine($"Ho tên: {HoTen}, Năm sinh: {NamSinh}, Quê quan: {QueQuan}, So CMND: {SoCMND}");
    }
}

class CBGV
{
    public Nguoi ThongTinCaNhan { get; set; }
    public double LuongCung { get; set; }
    public double Thuong { get; set; }
    public double Phat { get; set; }
    public double LuongThucLinh => LuongCung + Thuong - Phat;

    public void NhapThongTin()
    {
        ThongTinCaNhan = new Nguoi();
        ThongTinCaNhan.NhapThongTin();
        Console.Write("Lương cung: ");
        LuongCung = double.Parse(Console.ReadLine());
        Console.Write("Thưong: ");
        Thuong = double.Parse(Console.ReadLine());
        Console.Write("Phat: ");
        Phat = double.Parse(Console.ReadLine());
    }

    public void HienThiThongTin()
    {
        ThongTinCaNhan.HienThiThongTin();
        Console.WriteLine($"Lương cung: {LuongCung}, Thưong: {Thuong}, Phat: {Phat}, Lương thuc linh: {LuongThucLinh}");
    }
}

class QuanLyCBGV
{
    private List<CBGV> danhSachCBGV = new List<CBGV>();

    public void NhapDanhSach()
    {
        Console.Write("Nhap so can bo giao viên: ");
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nNhap thông tin can bo giao viên {i + 1}:");
            CBGV cbgv = new CBGV();
            cbgv.NhapThongTin();
            danhSachCBGV.Add(cbgv);
        }
    }

    public void TimKiemTheoQueQuan()
    {
        Console.Write("Nhap quê quan can tim: ");
        string queQuan = Console.ReadLine();
        foreach (var cbgv in danhSachCBGV)
        {
            if (cbgv.ThongTinCaNhan.QueQuan.Equals(queQuan, StringComparison.OrdinalIgnoreCase))
            {
                cbgv.HienThiThongTin();
                Console.WriteLine("--------------------");
            }
        }
    }

    public void HienThiLuongTren5Trieu()
    {
        foreach (var cbgv in danhSachCBGV)
        {
            if (cbgv.LuongThucLinh > 5000000)
            {
                cbgv.HienThiThongTin();
                Console.WriteLine("--------------------");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        QuanLyCBGV quanLy = new QuanLyCBGV();
        while (true)
        {
            Console.WriteLine("\nChon chuc năng: 1. Nhap CBGV | 2. Tim theo quê quan | 3. Hien thi lương > 5 trieu | 4. Thoat");
            int chon = int.Parse(Console.ReadLine());
            switch (chon)
            {
                case 1:
                    quanLy.NhapDanhSach();
                    break;
                case 2:
                    quanLy.TimKiemTheoQueQuan();
                    break;
                case 3:
                    quanLy.HienThiLuongTren5Trieu();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Lua cho không hop le!");
                    break;
            }
        }
    }
}

