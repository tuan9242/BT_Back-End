// Bài 2: Một thư viện cần quản lý các tài liệu bao gồm, Sách, Tạp chí, Báo
// +Mỗi tài liệu có các thuộc tính: Mã tài liệu, Tên nhà xuất bản, Số bản phát hành.
// + Các loại sách cần quản lý: Tên tác giả, số trang
// + Các tạp chí cần quản lý: Số phát hành, tháng phát hành
// + Các báo cần quản lý: ngày phát hành.
// 1. Xây dựng các lớp để quản lý các loại tài liệu trên sao cho việc sử dụng lại được nhiều nhất.
// 2. Xây dựng lớp QuanLyTailieu cài đặt các phương thức thực hiện các công việc sau:
//   -Nhập thông tin về các tài liệu (Hỏi người dùng muốn nhập thông tin cho loại tài liệu nào: Sách, Tạp chí hay Báo và nhập đúng thông tin cho loại tài liệu đó).
//   - Hiển thị thông tin về các tài liệu
//   - Tìm kiếm tài liệu theo loại
//   - Thoát khỏi chương trình


using System;
using System.Collections.Generic;
class TaiLieu
{
    public string MaTaiLieu { get; set; }
    public string TenNhaXuatBan { get; set; }
    public int SoBanPhatHanh { get; set; }

    public virtual void NhapThongTin()
    {
        Console.Write("Ma tai lieu: ");
        MaTaiLieu = Console.ReadLine();
        Console.Write("Tên nha xuat ban: ");
        TenNhaXuatBan = Console.ReadLine();
        Console.Write("So ban phat hanh: ");
        SoBanPhatHanh = int.Parse(Console.ReadLine());
    }
    public virtual void HienThiThongTin()
    {
        Console.WriteLine($"Ma: {MaTaiLieu}, NXB: {TenNhaXuatBan}, So ban: {SoBanPhatHanh}");
    }
}
class Sach : TaiLieu
{
    public string TenTacGia { get; set; }
    public int SoTrang { get; set; }

    public override void NhapThongTin()
    {
        base.NhapThongTin();
        Console.Write("Tên tac gia: ");
        TenTacGia = Console.ReadLine();
        Console.Write("So trang: ");
        SoTrang = int.Parse(Console.ReadLine());
    }
    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Tac gia: {TenTacGia}, So trang: {SoTrang}");
    }
}
class TapChi : TaiLieu
{
    public int SoPhatHanh { get; set; }
    public int ThangPhatHanh { get; set; }

    public override void NhapThongTin()
    {
        base.NhapThongTin();
        Console.Write("So phat hanh: ");
        SoPhatHanh = int.Parse(Console.ReadLine());
        Console.Write("Thang phat hanh: ");
        ThangPhatHanh = int.Parse(Console.ReadLine());
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"So phat hanh: {SoPhatHanh}, Thang phat hanh: {ThangPhatHanh}");
    }
}
class Bao : TaiLieu
{
    public string NgayPhatHanh { get; set; }

    public override void NhapThongTin()
    {
        base.NhapThongTin();
        Console.Write("Ngay phat hanh (dd/MM/yyyy): ");
        NgayPhatHanh = Console.ReadLine();
    }
    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Ngay phat hanh: {NgayPhatHanh}");
    }
}
class QuanLyTaiLieu
{
    private List<TaiLieu> danhSachTaiLieu = new List<TaiLieu>();

    public void NhapTaiLieu()
    {
        Console.WriteLine("Nhap loai tai lieu (1: Sach, 2: Tap chi, 3: Bao): ");
        int loai = int.Parse(Console.ReadLine());
        TaiLieu taiLieu;

        switch (loai)
        {
            case 1:
                taiLieu = new Sach();
                break;
            case 2:
                taiLieu = new TapChi();
                break;
            case 3:
                taiLieu = new Bao();
                break;
            default:
                Console.WriteLine("Lua chon không hop le!");
                return;
        }
        taiLieu.NhapThongTin();
        danhSachTaiLieu.Add(taiLieu);
    }

    public void HienThiDanhSach()
    {
        foreach (var tl in danhSachTaiLieu)
        {
            tl.HienThiThongTin();
            Console.WriteLine("------------------");
        }
    }

    public void TimKiemTheoLoai()
    {
        Console.WriteLine("Nhap loai tai lieu can tim (1: Sach, 2: Tap chi, 3: Bao): ");
        int loai = int.Parse(Console.ReadLine());

        foreach (var tl in danhSachTaiLieu)
        {
            if ((loai == 1 && tl is Sach) || (loai == 2 && tl is TapChi) || (loai == 3 && tl is Bao))
            {
                tl.HienThiThongTin();
                Console.WriteLine("------------------");
            }
        }
    }
}
class Program
{
    static void Main()
    {
        QuanLyTaiLieu qltl = new QuanLyTaiLieu();
        while (true)
        {
            Console.WriteLine("Chon chuc năng: 1. Nhap tai lieu | 2. Hien thi | 3. Tim kiem | 4. Thoat");
            int chon = int.Parse(Console.ReadLine());
            switch (chon)
            {
                case 1:
                    qltl.NhapTaiLieu();
                    break;
                case 2:
                    qltl.HienThiDanhSach();
                    break;
                case 3:
                    qltl.TimKiemTheoLoai();
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
