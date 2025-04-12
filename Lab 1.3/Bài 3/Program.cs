// Bài 3: Các thí sinh dự thi đại học bao gồm các thí sinh thi khối A, thí sinh thi khối B, thí sinh thi khối C
//       + Các thí sinh cần quản lý các thuộc tính: Số báo danh, họ tên, địa chỉ, ưu tiên.
//       + Thí sinh thi khối A thi các môn: Toán, lý, hoá
//       + Thí sinh thi khối B thi các môn: Toán, Hoá, Sinh
//       + Thí sinh thi khối C thi các môn: Văn, Sử, Địa
//    1. Xây dựng các lớp để quản lý các thí sinh sao cho sử dụng lại được nhiều nhất.
//    2. Xây dựng lớp TuyenSinh cài đặt các phương thức thực hiện các nhiệm vụ sau:
//         -Nhập thông tin về các thí sinh dự thi
//         - Hiển thị thông tin về các thí sinh đã trúng tuyển (Giả sử điểm chuẩn cho khối A: 15, điểm chuẩn khối B: 16, điểm chuẩn khối C: 13,5).
//         -Tìm kiếm các thí sinh theo số báo danh
//         - Kết thúc chương trình.

using System;
using System.Collections.Generic;
class ThiSinh
{
    public string SoBaoDanh { get; set; }
    public string HoTen { get; set; }
    public string DiaChi { get; set; }
    public int UuTien { get; set; }
    public double DiemToan { get; set; }
    public double DiemMon2 { get; set; }
    public double DiemMon3 { get; set; }

    public virtual void NhapThongTin()
    {
        Console.Write("So bao danh: ");
        SoBaoDanh = Console.ReadLine();
        Console.Write("Ho tên: ");
        HoTen = Console.ReadLine();
        Console.Write("Đia chi: ");
        DiaChi = Console.ReadLine();
        Console.Write("Điem ưu tiên: ");
        UuTien = int.Parse(Console.ReadLine());
    }
    public virtual void HienThiThongTin()
    {
        Console.WriteLine($"SBD: {SoBaoDanh}, Ho ten: {HoTen}, Đia chi: {DiaChi}, Ưu tiên: {UuTien}");
    }
    public double TongDiem() => DiemToan + DiemMon2 + DiemMon3 + UuTien;
}

class KhoiA : ThiSinh
{
    public override void NhapThongTin()
    {
        base.NhapThongTin();
        Console.Write("Điem Toan: ");
        DiemToan = double.Parse(Console.ReadLine());
        Console.Write("Điem Ly: ");
        DiemMon2 = double.Parse(Console.ReadLine());
        Console.Write("Điem Hoa: ");
        DiemMon3 = double.Parse(Console.ReadLine());
    }
}
class KhoiB : ThiSinh
{
    public override void NhapThongTin()
    {
        base.NhapThongTin();
        Console.Write("Điem Toan: ");
        DiemToan = double.Parse(Console.ReadLine());
        Console.Write("Điem Hoa: ");
        DiemMon2 = double.Parse(Console.ReadLine());
        Console.Write("Điem Sinh: ");
        DiemMon3 = double.Parse(Console.ReadLine());
    }
}
class KhoiC : ThiSinh
{
    public override void NhapThongTin()
    {
        base.NhapThongTin();
        Console.Write("Điem Văn: ");
        DiemToan = double.Parse(Console.ReadLine());
        Console.Write("Điem Su: ");
        DiemMon2 = double.Parse(Console.ReadLine());
        Console.Write("Điem Đia: ");
        DiemMon3 = double.Parse(Console.ReadLine());
    }
}
class TuyenSinh
{
    private List<ThiSinh> danhSachThiSinh = new List<ThiSinh>();

    public void NhapThiSinh()
    {
        Console.WriteLine("Chon khoi thi (1: A, 2: B, 3: C): ");
        int loai = int.Parse(Console.ReadLine());
        ThiSinh ts;

        switch (loai)
        {
            case 1:
                ts = new KhoiA();
                break;
            case 2:
                ts = new KhoiB();
                break;
            case 3:
                ts = new KhoiC();
                break;
            default:
                Console.WriteLine("Lua chon không hop le!");
                return;
        }

        ts.NhapThongTin();
        danhSachThiSinh.Add(ts);
    }

    public void HienThiTrungTuyen()
    {
        Console.WriteLine("Danh sach thi sinh trung tuyen:");
        foreach (var ts in danhSachThiSinh)
        {
            double diemChuan = ts is KhoiA ? 15 : ts is KhoiB ? 16 : 13.5;
            if (ts.TongDiem() >= diemChuan)
            {
                ts.HienThiThongTin();
                Console.WriteLine($"Tong điem: {ts.TongDiem()}");
                Console.WriteLine("------------------");
            }
        }
    }

    public void TimKiemThiSinh()
    {
        Console.Write("Nhap so bao danh can tim: ");
        string sbd = Console.ReadLine();
        foreach (var ts in danhSachThiSinh)
        {
            if (ts.SoBaoDanh.Equals(sbd, StringComparison.OrdinalIgnoreCase))
            {
                ts.HienThiThongTin();
                Console.WriteLine($"Tong điem: {ts.TongDiem()}");
                return;
            }
        }
        Console.WriteLine("Không tim thay thi sinh!");
    }
}
class Program
{
    static void Main()
    {
        TuyenSinh ts = new TuyenSinh();
        while (true)
        {
            Console.WriteLine("Chon chuc năng: 1. Nhap thi sinh | 2. Hien thị trung tuyen | 3. Tim kiem | 4. Thoat");
            int chon = int.Parse(Console.ReadLine());
            switch (chon)
            {
                case 1:
                    ts.NhapThiSinh();
                    break;
                case 2:
                    ts.HienThiTrungTuyen();
                    break;
                case 3:
                    ts.TimKiemThiSinh();
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
