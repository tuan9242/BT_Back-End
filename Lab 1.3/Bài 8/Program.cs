// Bài 8: Thư viện của trường đại học Đại Nam có nhu cầu cần quản lý việc mượn sách.
// Sinh viên đăng ký và tham gia mượn sách thông qua các thẻ mượn mà thư viện đã thiết kế.
//      - Với mỗi thẻ mượn, có các thông tin sau: số phiếu mượn, ngày mượn, hạn trả, số hiệu sách, và các thông tin riêng về mỗi sinh viên đó.
//      - Các thông tin riêng về mỗi sinh viên đó bao gồm: Họ tên, năm sinh, lớp, mã số sinh viên.
//  1. Hãy xây dựng lớp SinhVien để quản lý các thông tin riêng về mỗi sinh viên.
//  2. Xây dựng lớp TheMuon để quản lý việc mượn sách của mỗi độc giả.
//  3. Xây dựng các phương thức để nhập và hiện thị các thông tin riêng cho mỗi sinh viên .
//  4. Nhập vào một danh sách các sinh viên, sau đó thực hiện các công việc sau:
//      -Tìm kiếm thông tin về sinh viên theo mã số sinh viên; -Hiển thị thông tin về các sinh viên đã đến hạn trả sách theo ngày hiện tại;
//      -Thoát khỏi chương trình.

using System;
using System.Collections.Generic;

class SinhVien
{
    public string HoTen { get; set; }
    public int NamSinh { get; set; }
    public string Lop { get; set; }
    public string MaSV { get; set; }

    public void NhapThongTin()
    {
        Console.Write("Ho tên: ");
        HoTen = Console.ReadLine();
        Console.Write("Nam sinh: ");
        NamSinh = int.Parse(Console.ReadLine());
        Console.Write("Lop: ");
        Lop = Console.ReadLine();
        Console.Write("Ma sinh viên: ");
        MaSV = Console.ReadLine();
    }

    public void HienThiThongTin()
    {
        Console.WriteLine($"Ho tên: {HoTen}, Năm sinh: {NamSinh}, Lop: {Lop}, Ma SV: {MaSV}");
    }
}

class TheMuon
{
    public string SoPhieuMuon { get; set; }
    public DateTime NgayMuon { get; set; }
    public DateTime HanTra { get; set; }
    public string SoHieuSach { get; set; }
    public SinhVien ThongTinSinhVien { get; set; }

    public void NhapThongTin()
    {
        ThongTinSinhVien = new SinhVien();
        ThongTinSinhVien.NhapThongTin();
        Console.Write("So phieu mưon: ");
        SoPhieuMuon = Console.ReadLine();
        Console.Write("Ngay mưon (yyyy-mm-dd): ");
        NgayMuon = DateTime.Parse(Console.ReadLine());
        Console.Write("Han tra (yyyy-mm-dd): ");
        HanTra = DateTime.Parse(Console.ReadLine());
        Console.Write("So hieu sach: ");
        SoHieuSach = Console.ReadLine();
    }

    public void HienThiThongTin()
    {
        ThongTinSinhVien.HienThiThongTin();
        Console.WriteLine($"So phieu: {SoPhieuMuon}, Ngay mưon: {NgayMuon:yyyy-MM-dd}, Han tra: {HanTra:yyyy-MM-dd}, So hieệu sach: {SoHieuSach}");
    }
}

class QuanLyTheMuon
{
    private List<TheMuon> danhSachTheMuon = new List<TheMuon>();

    public void NhapDanhSach()
    {
        Console.Write("Nhap so lưong the mưon: ");
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nNhap thông tin the mưon {i + 1}:");
            TheMuon theMuon = new TheMuon();
            theMuon.NhapThongTin();
            danhSachTheMuon.Add(theMuon);
        }
    }

    public void TimKiemTheoMaSV()
    {
        Console.Write("Nhap ma sinh viên can tim: ");
        string maSV = Console.ReadLine();
        foreach (var theMuon in danhSachTheMuon)
        {
            if (theMuon.ThongTinSinhVien.MaSV.Equals(maSV, StringComparison.OrdinalIgnoreCase))
            {
                theMuon.HienThiThongTin();
                Console.WriteLine("--------------------");
            }
        }
    }

    public void HienThiDanhSachDenHanTra()
    {
        DateTime ngayHienTai = DateTime.Now;
        foreach (var theMuon in danhSachTheMuon)
        {
            if (theMuon.HanTra <= ngayHienTai)
            {
                theMuon.HienThiThongTin();
                Console.WriteLine("--------------------");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        QuanLyTheMuon quanLy = new QuanLyTheMuon();
        while (true)
        {
            Console.WriteLine("\nChon chuc năng: 1. Nhap the mưon | 2. Tim theo ma SV | 3. Hien thi danh sach đen han tra | 4. Thoat");
            int chon = int.Parse(Console.ReadLine());
            switch (chon)
            {
                case 1:
                    quanLy.NhapDanhSach();
                    break;
                case 2:
                    quanLy.TimKiemTheoMaSV();
                    break;
                case 3:
                    quanLy.HienThiDanhSachDenHanTra();
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
