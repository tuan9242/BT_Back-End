// Bài 5: Để quản lý khách hàng đến thuê phòng của một khách sạn, người ta cần quản lý những thông tin sau:
//          -Số ngày trọ, loại phòng trọ, giá phòng, và các thông tin cá nhân về mỗi khách trọ.
//          - Với mỗi cá nhân, người ta cần quản lý các thông tin : Họ và tên, năm sinh, số chứng minh thư nhân dân.
//      1. Hãy xây dựng lớp Nguoi để quản lý thông tin cá nhân về mỗi cá nhân.
//      2. Xây dựng lớp KhachSan để quản lý các thông tin về khách thuê phòng.
//      3. Viết các phương thức : nhập, hiển thị các thông tin về mỗi khách thuê phòng.
//      4. Cài đặt chương trình thực hiện các công việc sau:
//          -Nhập vào một dãy gồm n khách trọ ( n - nhập từ bàn phím)
//          - Hiển thị ra màn hình thông tin về các cá nhân hiện đang trọ ở khách sạn đó.
//          - Tìm kiếm thông tin về những khách thuê phòng theo họ và tên.
//          - Tính tiền cho khách hàng khi thanh toán trả phòng
//          - Thoát khỏi chương trình.

using System;
using System.Collections.Generic;

class Nguoi
{
    public string HoTen { get; set; }
    public int NamSinh { get; set; }
    public string CMND { get; set; }

    public void NhapThongTin()
    {
        Console.Write("Ho ten: ");
        HoTen = Console.ReadLine();
        Console.Write("Năm sinh: ");
        NamSinh = int.Parse(Console.ReadLine());
        Console.Write("So CMND: ");
        CMND = Console.ReadLine();
    }

    public void HienThiThongTin()
    {
        Console.WriteLine($"Ho tên: {HoTen}, Năm sinh: {NamSinh}, CMND: {CMND}");
    }
}

class KhachSan
{
    private class KhachThue
    {
        public Nguoi Khach { get; set; }
        public int SoNgayTro { get; set; }
        public string LoaiPhong { get; set; }
        public double GiaPhong { get; set; }

        public void NhapThongTin()
        {
            Khach = new Nguoi();
            Khach.NhapThongTin();
            Console.Write("So ngay tro: ");
            SoNgayTro = int.Parse(Console.ReadLine());
            Console.Write("Loai phong: ");
            LoaiPhong = Console.ReadLine();
            Console.Write("Gia phong: ");
            GiaPhong = double.Parse(Console.ReadLine());
        }

        public void HienThiThongTin()
        {
            Khach.HienThiThongTin();
            Console.WriteLine($"So ngay tro: {SoNgayTro}, Loai phong: {LoaiPhong}, Gia phong: {GiaPhong}");
        }

        public double TinhTien()
        {
            return SoNgayTro * GiaPhong;
        }
    }

    private List<KhachThue> danhSachKhach = new List<KhachThue>();

    public void NhapDanhSachKhach()
    {
        Console.Write("Nhap so khach tro: ");
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Nhap thông tin cho khach {i + 1}:");
            KhachThue khach = new KhachThue();
            khach.NhapThongTin();
            danhSachKhach.Add(khach);
        }
    }

    public void HienThiDanhSachKhach()
    {
        foreach (var khach in danhSachKhach)
        {
            khach.HienThiThongTin();
            Console.WriteLine("--------------------");
        }
    }

    public void TimKiemKhach()
    {
        Console.Write("Nhap ho tên khach can tim: ");
        string hoTen = Console.ReadLine();
        foreach (var khach in danhSachKhach)
        {
            if (khach.Khach.HoTen.Equals(hoTen, StringComparison.OrdinalIgnoreCase))
            {
                khach.HienThiThongTin();
                return;
            }
        }
        Console.WriteLine("Khong tìm thay khach hang!");
    }

    public void TinhTienKhach()
    {
        Console.Write("Nhap ho tên khach can tinh tien: ");
        string hoTen = Console.ReadLine();
        foreach (var khach in danhSachKhach)
        {
            if (khach.Khach.HoTen.Equals(hoTen, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"So tien can thanh toan: {khach.TinhTien()} VNĐ");
                return;
            }
        }
        Console.WriteLine("Không tìm thay khach hang!");
    }
}

class Program
{
    static void Main()
    {
        KhachSan khachSan = new KhachSan();
        while (true)
        {
            Console.WriteLine("Chon chuc nang: 1. Nhap khach tro | 2. Hien thi danh sach | 3. Tim kiem | 4. Tính tien | 5. Thoat");
            int chon = int.Parse(Console.ReadLine());
            switch (chon)
            {
                case 1:
                    khachSan.NhapDanhSachKhach();
                    break;
                case 2:
                    khachSan.HienThiDanhSachKhach();
                    break;
                case 3:
                    khachSan.TimKiemKhach();
                    break;
                case 4:
                    khachSan.TinhTienKhach();
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Lua chon không hop le!");
                    break;
            }
        }
    }
}
