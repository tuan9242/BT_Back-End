// Bài 19:
//  1.Xây dựng một lớp THISINH gồm các thông tin sau: Họ tên, quê quán, trường, tuổi, số báo danh, điểm thi. Trong đó họ tên lại là một cấu trúc gồm ba thành phần: họ, tên đệm và tê.
//  Quê quán cũng là một cấu trúc gồm ba thàh phần: xã, huyện và tỉnh. Điểm thi là một cấu trúc gồm ba thành phần: toán, lý, hoá (điểm chấm chính xác đến 1 / 4).
//  2. Đọc số liệu từ một phiếu điểm cụ thể và lưu trữ rồi sau đó in ra màn hình.
//  3. Xây dựng một danh sách các THISINH.
//  4. Nhập số liệu từ N phiếu điểm (N nhập vào từ bàn phím).
//  5. Tìm kiếm và in ra các thí sinh có tổng điểm ba môn lớn hơn 15.
//  6. Hãy lập chương trình sắp xếp lại danh sách theo tổng điểm ba môn giảm dần. Sau đó in danh sách thông tin theo thứ tự nói trên. Hiển thị thông tin về các thí sinh theo dạng bảng, mỗi
//  thí sinh gồm các thông tin sau: Họ tên, Quê quán, Số báo danh, Điểm toán, lý, hoá

using System;
using System.Collections.Generic;
using System.Linq;

class HoTen
{
    public string Ho;
    public string Dem;
    public string Ten;

    public HoTen(string ho, string dem, string ten)
    {
        Ho = ho;
        Dem = dem;
        Ten = ten;
    }

    public override string ToString()
    {
        return $"{Ho} {Dem} {Ten}";
    }
}

class QueQuan
{
    public string Xa;
    public string Huyen;
    public string Tinh;

    public QueQuan(string xa, string huyen, string tinh)
    {
        Xa = xa;
        Huyen = huyen;
        Tinh = tinh;
    }

    public override string ToString()
    {
        return $"{Xa}, {Huyen}, {Tinh}";
    }
}

class DiemThi
{
    public double Toan;
    public double Ly;
    public double Hoa;

    public DiemThi(double toan, double ly, double hoa)
    {
        Toan = toan;
        Ly = ly;
        Hoa = hoa;
    }

    public double TongDiem()
    {
        return Toan + Ly + Hoa;
    }
}

class ThiSinh
{
    public HoTen HoTen;
    public QueQuan QueQuan;
    public string Truong;
    public int Tuoi;
    public string SoBaoDanh;
    public DiemThi Diem;

    public ThiSinh(HoTen hoTen, QueQuan queQuan, string truong, int tuoi, string soBaoDanh, DiemThi diem)
    {
        HoTen = hoTen;
        QueQuan = queQuan;
        Truong = truong;
        Tuoi = tuoi;
        SoBaoDanh = soBaoDanh;
        Diem = diem;
    }

    public void InThongTin()
    {
        Console.WriteLine($"{HoTen,-20} | {QueQuan,-30} | {SoBaoDanh,-10} | {Diem.Toan,5:F2} | {Diem.Ly,5:F2} | {Diem.Hoa,5:F2} | Tổng: {Diem.TongDiem(),5:F2}");
    }
}

class Program
{
    static void Main()
    {
        List<ThiSinh> danhSach = new List<ThiSinh>();

        Console.Write("Nhap so lưong thi sinh: ");
        int N = int.Parse(Console.ReadLine());

        for (int i = 0; i < N; i++)
        {
            Console.WriteLine($"\n--- Nhap thông tin thi sinh thu {i + 1} ---");

            Console.Write("Ho: ");
            string ho = Console.ReadLine();

            Console.Write("Tên đem: ");
            string dem = Console.ReadLine();

            Console.Write("Tên: ");
            string ten = Console.ReadLine();

            Console.Write("Xa: ");
            string xa = Console.ReadLine();

            Console.Write("Huyen: ");
            string huyen = Console.ReadLine();

            Console.Write("Tinh: ");
            string tinh = Console.ReadLine();

            Console.Write("Trưong: ");
            string truong = Console.ReadLine();

            Console.Write("Tuoi: ");
            int tuoi = int.Parse(Console.ReadLine());

            Console.Write("So bao danh: ");
            string sbd = Console.ReadLine();

            Console.Write("Điem Toan: ");
            double toan = double.Parse(Console.ReadLine());

            Console.Write("Điem Ly: ");
            double ly = double.Parse(Console.ReadLine());

            Console.Write("Điêm Hoa: ");
            double hoa = double.Parse(Console.ReadLine());

            var thiSinh = new ThiSinh(
                new HoTen(ho, dem, ten),
                new QueQuan(xa, huyen, tinh),
                truong,
                tuoi,
                sbd,
                new DiemThi(toan, ly, hoa)
            );

            danhSach.Add(thiSinh);
        }

        // Tìm thí sinh có tổng điểm > 15
        Console.WriteLine("\n=== Thi sinh co tong điem > 15 ===");
        foreach (var ts in danhSach)
        {
            if (ts.Diem.TongDiem() > 15)
                ts.InThongTin();
        }

        // Sắp xếp danh sách theo tổng điểm giảm dần
        danhSach.Sort((a, b) => b.Diem.TongDiem().CompareTo(a.Diem.TongDiem()));

        // Hiển thị danh sách theo bảng
        Console.WriteLine("\n=== Danh sach thi sinh sap xep theo tong điem giam dan ===");
        Console.WriteLine($"{"Họ tên",-20} | {"Quê quan",-30} | {"SBD",-10} | {"Toan",5} | {"Ly",5} | {"Hoa",5} | Tong");
        Console.WriteLine(new string('-', 90));
        foreach (var ts in danhSach)
        {
            ts.InThongTin();
        }
    }
}
