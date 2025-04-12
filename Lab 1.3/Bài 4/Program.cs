// Bài 4: Để quản lý các hộ dân trong một khu phố, người ta quản lý các thông tin như sau:
//      -Với mỗi hộ dân, có các thuộc tính:
//          +Số thành viên trong hộ (số người)
//          + Số nhà của hộ dân đó (số nhà được gắn cho mỗi hộ dân)
//          + Thông tin về mỗi cá nhân trong hộ gia đình.
//      - Với mỗi cá nhân, người ta quản lý các thông tin như: số chứng minh nhân dân, họ và tên, tuổi, năm sinh, nghề nghiệp.
//  1. Hãy xây dựng lớp Nguoi để quản lý thông tin về mỗi cá nhân.
//  2. Xây dựng lớp KhuPho để quản lý thông tin về các hộ gia đình.
//  3. Viết các phương thức nhập, hiển thị thông tin cho mỗi hộ gia đình.
//  4. Cài đặt chương trình thực hiện các công việc sau:
//      -Nhập vào một dãy gồm n hộ dân (n - nhập từ bàn phím).- Tìm kiếm thông tin về hộ dân theo họ tên hoặc theo số nhà
//      - Hiển thị thông tin cho toàn bộ các hộ dân trong khu phố.
//      - Thoát khỏi chương trình.

using System;
using System.Collections.Generic;
class Nguoi
{
    public string CMND { get; set; }
    public string HoTen { get; set; }
    public int Tuoi { get; set; }
    public int NamSinh { get; set; }
    public string NgheNghiep { get; set; }

    public void NhapThongTin()
    {
        Console.Write("So CMND: ");
        CMND = Console.ReadLine();
        Console.Write("Ho tên: ");
        HoTen = Console.ReadLine();
        Console.Write("Tuoi: ");
        Tuoi = int.Parse(Console.ReadLine());
        Console.Write("Nam sinh: ");
        NamSinh = int.Parse(Console.ReadLine());
        Console.Write("Nghe nghiep: ");
        NgheNghiep = Console.ReadLine();
    }
    public void HienThiThongTin()
    {
        Console.WriteLine($"CMND: {CMND}, Ho tên: {HoTen}, Tuoi: {Tuoi}, Năm sinh: {NamSinh}, Nghe nghiep: {NgheNghiep}");
    }
}
class HoDan
{
    public int SoThanhVien { get; set; }
    public int SoNha { get; set; }
    public List<Nguoi> ThanhVien { get; set; } = new List<Nguoi>();

    public void NhapThongTin()
    {
        Console.Write("So nha: ");
        SoNha = int.Parse(Console.ReadLine());
        Console.Write("So thanh viên: ");
        SoThanhVien = int.Parse(Console.ReadLine());
        for (int i = 0; i < SoThanhVien; i++)
        {
            Console.WriteLine($"Nap thông tin cho thanh viên {i + 1}:");
            Nguoi nguoi = new Nguoi();
            nguoi.NhapThongTin();
            ThanhVien.Add(nguoi);
        }
    }

    public void HienThiThongTin()
    {
        Console.WriteLine($"So nha: {SoNha}, So thanh viên: {SoThanhVien}");
        foreach (var tv in ThanhVien)
        {
            tv.HienThiThongTin();
        }
        Console.WriteLine("------------------");
    }
}

class KhuPho
{
    private List<HoDan> danhSachHoDan = new List<HoDan>();

    public void NhapDanhSachHoDan()
    {
        Console.Write("Nhap so ho dan: ");
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Nhap thong tin cho ho dân thu {i + 1}:");
            HoDan hoDan = new HoDan();
            hoDan.NhapThongTin();
            danhSachHoDan.Add(hoDan);
        }
    }

    public void HienThiDanhSachHoDan()
    {
        foreach (var hoDan in danhSachHoDan)
        {
            hoDan.HienThiThongTin();
        }
    }

    public void TimKiemHoDan()
    {
        Console.Write("Tim theo (1: Ho tên, 2: So nha): ");
        int luaChon = int.Parse(Console.ReadLine());
        if (luaChon == 1)
        {
            Console.Write("Nhap ho tên can tim: ");
            string hoTen = Console.ReadLine();
            foreach (var hoDan in danhSachHoDan)
            {
                foreach (var thanhVien in hoDan.ThanhVien)
                {
                    if (thanhVien.HoTen.Equals(hoTen, StringComparison.OrdinalIgnoreCase))
                    {
                        hoDan.HienThiThongTin();
                        return;
                    }
                }
            }
        }
        else if (luaChon == 2)
        {
            Console.Write("Nhap so nha can tim: ");
            int soNha = int.Parse(Console.ReadLine());
            foreach (var hoDan in danhSachHoDan)
            {
                if (hoDan.SoNha == soNha)
                {
                    hoDan.HienThiThongTin();
                    return;
                }
            }
        }
        else
        {
            Console.WriteLine("Lua chon không hop le!");
        }
    }
}

class Program
{
    static void Main()
    {
        KhuPho khuPho = new KhuPho();
        while (true)
        {
            Console.WriteLine("Chon chuc năng: 1. Nhap ho dân | 2. Hien thi danh sach | 3. Tim kiem | 4. Thoat");
            int chon = int.Parse(Console.ReadLine());
            switch (chon)
            {
                case 1:
                    khuPho.NhapDanhSachHoDan();
                    break;
                case 2:
                    khuPho.HienThiDanhSachHoDan();
                    break;
                case 3:
                    khuPho.TimKiemHoDan();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Lua con không hop le!");
                    break;
            }
        }
    }
}
