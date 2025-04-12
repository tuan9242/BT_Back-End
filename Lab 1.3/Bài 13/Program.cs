// Bài 13: Một công ty được giao nhiệm vụ quản lý các phương tiện giao thông gồm các loại: ô tô, xe máy, xe tải.
//          + mỗi loại phương tiện giao thông cần quản lý: Hãng sản xuất, năm sản xuất, giá bán và màu.
//          + Các ô tô cần quản lý: số chỗ ngồi, kiểu động cơ+ Xe máy cần quản lý: công suất
//          + Xe tải cần quản lý: trọng tải.
//      1.Xây dựng các lớp XeTai, XeMay, OTo kế thừa từ lớp PTGT.
//      2. Xây dựng các hàm để truy nhập, hiển thị và kiểm tra các thuộc tính của các lớp.
//      3. Xây dựng lớp QLPTGT cài đặt các phương thức thực hiện các chức năng sau:
//          -Nhập đăng ký phương tiện
//          - Tìm phương tiện theo màu hoặc theo năm sản xuất.
//          - Kết thúc chương trình


using System;
using System.Collections.Generic;

class PTGT
{
    public string HangSanXuat { get; set; }
    public int NamSanXuat { get; set; }
    public double GiaBan { get; set; }
    public string Mau { get; set; }

    public PTGT(string hangSanXuat, int namSanXuat, double giaBan, string mau)
    {
        HangSanXuat = hangSanXuat;
        NamSanXuat = namSanXuat;
        GiaBan = giaBan;
        Mau = mau;
    }

    public virtual void HienThi()
    {
        Console.WriteLine($"Hang: {HangSanXuat}, Năm: {NamSanXuat}, Gia: {GiaBan}, Mau: {Mau}");
    }
}

class OTo : PTGT
{
    public int SoChoNgoi { get; set; }
    public string KieuDongCo { get; set; }

    public OTo(string hang, int nam, double gia, string mau, int soCho, string kieuDongCo)
        : base(hang, nam, gia, mau)
    {
        SoChoNgoi = soCho;
        KieuDongCo = kieuDongCo;
    }

    public override void HienThi()
    {
        base.HienThi();
        Console.WriteLine($"Loai: Ô Tô, So cho: {SoChoNgoi}, Kieu đong cơ: {KieuDongCo}");
    }
}
class XeMay : PTGT
{
    public double CongSuat { get; set; }

    public XeMay(string hang, int nam, double gia, string mau, double congSuat)
        : base(hang, nam, gia, mau)
    {
        CongSuat = congSuat;
    }

    public override void HienThi()
    {
        base.HienThi();
        Console.WriteLine($"Loai: Xe May, Công suat: {CongSuat} ma luc");
    }
}

class XeTai : PTGT
{
    public double TrongTai { get; set; }

    public XeTai(string hang, int nam, double gia, string mau, double trongTai)
        : base(hang, nam, gia, mau)
    {
        TrongTai = trongTai;
    }

    public override void HienThi()
    {
        base.HienThi();
        Console.WriteLine($"Loai: Xe Tai, Trong tai: {TrongTai} tan");
    }
}

class QLPTGT
{
    private List<PTGT> danhSach = new List<PTGT>();

    public void ThemPhuongTien(PTGT pt)
    {
        danhSach.Add(pt);
    }

    public void TimTheoMau(string mau)
    {
        Console.WriteLine($"== Ket qua tim theo mau '{mau}': ==");
        foreach (var pt in danhSach)
        {
            if (pt.Mau.Equals(mau, StringComparison.OrdinalIgnoreCase))
            {
                pt.HienThi();
                Console.WriteLine();
            }
        }
    }

    public void TimTheoNam(int nam)
    {
        Console.WriteLine($"== Ket qua tim theo năm san xuat '{nam}': ==");
        foreach (var pt in danhSach)
        {
            if (pt.NamSanXuat == nam)
            {
                pt.HienThi();
                Console.WriteLine();
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        QLPTGT ql = new QLPTGT();

        // Thêm một số phương tiện mẫu
        ql.ThemPhuongTien(new OTo("Toyota", 2020, 500000000, "Đo", 5, "Xăng"));
        ql.ThemPhuongTien(new XeMay("Honda", 2022, 30000000, "Đen", 150));
        ql.ThemPhuongTien(new XeTai("Hyundai", 2019, 700000000, "Trang", 5));

        Console.WriteLine("\n== Tim theo mau ==");
        ql.TimTheoMau("Đỏ");

        Console.WriteLine("\n== Tim theo năm ==");
        ql.TimTheoNam(2022);

        Console.WriteLine("\n== Ket thuc chương trinh ==");
    }
}
