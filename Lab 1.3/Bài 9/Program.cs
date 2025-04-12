// Bài 9: Để quản lý các biên lai thu tiền điện, người ta cần các thông tin như sau:
//          -Với mỗi biên lai, có các thông tin sau: thông tin về hộ sử dụng điện, chỉ số cũ, chỉ số mới, số tiền phải trả của mỗi hộ sử dụng điện
//          - Các thông tin riêng của mỗi hộ sử dụng điện gồm: Họ tên chủ hộ, số nhà, mã số công tơ của hộ dân sử dụng điện.
//      1. Hãy xây dựng lớp KhachHang để lưu trữ các thông tin riêng của mỗi hộ sử dụng điện.
//      2. Xây dựng lớp BienLai để quản lý việc sử dụng và thanh toán tiền điện của các hộ dân.
//      3. Xây dựng các phương thức nhập, và hiển thị thông tin riêng của mỗi hộ sử dụng điện.
//      4. Cài đặt chương trình thực hiện các công việc sau:
//          +Nhập vào các thông tin cho N hộ sử dụng điện
//          + Hiển thị thông tin về các biên lai đã nhập
//          + Tính tiền điện phải trả cho mỗi hộ dân, nếu giả sử rằng tiền phải trả được tính theo  công thức sau:
//              Số điện Giá tiền
//              Dưới 50 số 1250 vnđ/1 số
//              Từ 50 đến dưới 100 số 1500 vnđ/1 số
//              Từ 100 số trở lên 2000 vnđ/1 số

using System;
using System.Collections.Generic;

class KhachHang
{
    public string HoTenChuHo { get; set; }
    public string SoNha { get; set; }
    public string MaSoCongTo { get; set; }

    public void NhapThongTin()
    {
        Console.Write("Ho tên chu ho: ");
        HoTenChuHo = Console.ReadLine();
        Console.Write("So nha: ");
        SoNha = Console.ReadLine();
        Console.Write("Ma so công tơ: ");
        MaSoCongTo = Console.ReadLine();
    }

    public void HienThiThongTin()
    {
        Console.WriteLine($"Ho tên: {HoTenChuHo}, So nha: {SoNha}, Ma so công tơ: {MaSoCongTo}");
    }
}

class BienLai
{
    public KhachHang ThongTinKhachHang { get; set; }
    public int ChiSoCu { get; set; }
    public int ChiSoMoi { get; set; }
    public int SoTienPhaiTra { get; private set; }

    public void NhapThongTin()
    {
        ThongTinKhachHang = new KhachHang();
        ThongTinKhachHang.NhapThongTin();
        Console.Write("Chi so cu: ");
        ChiSoCu = int.Parse(Console.ReadLine());
        Console.Write("Chi so moi: ");
        ChiSoMoi = int.Parse(Console.ReadLine());
        TinhTienDien();
    }

    private void TinhTienDien()
    {
        int soDien = ChiSoMoi - ChiSoCu;
        if (soDien <= 50)
            SoTienPhaiTra = soDien * 1250;
        else if (soDien < 100)
            SoTienPhaiTra = 50 * 1250 + (soDien - 50) * 1500;
        else
            SoTienPhaiTra = 50 * 1250 + 50 * 1500 + (soDien - 100) * 2000;
    }

    public void HienThiThongTin()
    {
        ThongTinKhachHang.HienThiThongTin();
        Console.WriteLine($"Chi so cu: {ChiSoCu}, Chi so moi: {ChiSoMoi}, Tien phai tra: {SoTienPhaiTra} VND");
    }
}

class QuanLyBienLai
{
    private List<BienLai> danhSachBienLai = new List<BienLai>();

    public void NhapDanhSach()
    {
        Console.Write("Nhap so ho su dung đien: ");
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nNhap thông tin biên lai {i + 1}:");
            BienLai bienLai = new BienLai();
            bienLai.NhapThongTin();
            danhSachBienLai.Add(bienLai);
        }
    }

    public void HienThiDanhSach()
    {
        foreach (var bienLai in danhSachBienLai)
        {
            bienLai.HienThiThongTin();
            Console.WriteLine("--------------------");
        }
    }
}

class Program
{
    static void Main()
    {
        QuanLyBienLai quanLy = new QuanLyBienLai();
        while (true)
        {
            Console.WriteLine("\nChon chuc năng: 1. Nhap biên lai | 2. Hien thi biên lai | 3. Thoat");
            int chon = int.Parse(Console.ReadLine());
            switch (chon)
            {
                case 1:
                    quanLy.NhapDanhSach();
                    break;
                case 2:
                    quanLy.HienThiDanhSach();
                    break;
                case 3:
                    return;
                default:
                    Console.WriteLine("Lua chon không hop le!");
                    break;
            }
        }
    }
}
