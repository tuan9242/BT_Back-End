// Bài 18:
// 1. Thông tin về mỗi cá nhân bao gồm : Họ tên, giới tính, tuổi.
//      -Hãy xây dựng lớp Nguoi chứa các đối tượng là các cá nhân và xây dựng các phương thức:
//      -Các toán tử tạo lập: Nguoi(); Nguoi(String, boolean, int);
//      -Phương thức in() để in thông tin về một cá nhân
//  2. Hãy xây dựng lớp CoQuan chứa thông tin về các cá nhân trong một đơn vị được dẫn xuất từ lớp Nguoi và có thêm các thành phần:
//      -Thuộc tính kiểu String xác định đơn vị công tác (bộ môn, phòng), thuộc tính kiểu double xác định hệ số lương.
//      - Viết đè phương thức in() ở lớp Nguoi để in thông tin về một cá nhân trong CoQuan
//      - Cài đặt phương thức tinhLuong(CoQuan) để tính lương cho mỗi cá nhân trong cơ quan. Lương =hệ số lương x Lương cơ bản;
//  Trong đó lương cơ bản là một hằng số được quy định bởi nhà nước (Lương cơ bản ở thời điểm hiện tại đang là 1.050.000 vnđ).
//  3. Nhập vào một danh sách các cá nhân thuộc vào lớp CoQuan:
//      -Hiển thị thông tin cho cá nhân có đơn vị là Phòng tài chính;
//      -Tìm kiếm thông tin theo họ tên;
//      -Thoát khỏi chương trình.

using System;
using System.Collections.Generic;

class Nguoi
{
    public string HoTen;
    public bool GioiTinh; 
    public int Tuoi;

    public Nguoi() { }

    public Nguoi(string hoTen, bool gioiTinh, int tuoi)
    {
        HoTen = hoTen;
        GioiTinh = gioiTinh;
        Tuoi = tuoi;
    }

    public virtual void In()
    {
        Console.WriteLine($"Ho tên: {HoTen}");
        Console.WriteLine($"Gioi tinh: {(GioiTinh ? "Nam" : "Nu")}");
        Console.WriteLine($"Tuoi: {Tuoi}");
    }
}

class CoQuan : Nguoi
{
    public string DonVi;
    public double HeSoLuong;
    public static readonly double LUONG_CO_BAN = 1050000;

    public CoQuan() : base()
    {
        DonVi = "";
        HeSoLuong = 1.0;
    }

    public CoQuan(string hoTen, bool gioiTinh, int tuoi, string donVi, double heSoLuong)
        : base(hoTen, gioiTinh, tuoi)
    {
        DonVi = donVi;
        HeSoLuong = heSoLuong;
    }

    public override void In()
    {
        base.In();
        Console.WriteLine($"Đơn vi: {DonVi}");
        Console.WriteLine($"He so lương: {HeSoLuong}");
        Console.WriteLine($"Lương: {TinhLuong():N0} VNĐ");
    }

    public double TinhLuong()
    {
        return HeSoLuong * LUONG_CO_BAN;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<CoQuan> danhSach = new List<CoQuan>();

        Console.Write("Nhap so lưong ca nhân: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nNhap thông tin ca nhân thu {i + 1}:");

            Console.Write("Ho tên: ");
            string hoTen = Console.ReadLine();

            Console.Write("Gioi tinh (nam/nu): ");
            string gioiTinhStr = Console.ReadLine().Trim().ToLower();
            bool gioiTinh = gioiTinhStr == "nam";

            Console.Write("Tuoi: ");
            int tuoi = int.Parse(Console.ReadLine());

            Console.Write("Đơn vị công tac: ");
            string donVi = Console.ReadLine();

            Console.Write("He so lương: ");
            double heSoLuong = double.Parse(Console.ReadLine());

            danhSach.Add(new CoQuan(hoTen, gioiTinh, tuoi, donVi, heSoLuong));
        }

        // Menu
        int chon;
        do
        {
            Console.WriteLine("\n===== MENU =====");
            Console.WriteLine("1. Hien thi thông tin cac ca nhan o Phong tai chinh");
            Console.WriteLine("2. Tim kiem theo ho tên");
            Console.WriteLine("3. Thoat");
            Console.Write("Chon chuc năng: ");
            chon = int.Parse(Console.ReadLine());

            switch (chon)
            {
                case 1:
                    Console.WriteLine("\nCac ca nhân thuoc Phong tai chinh:");
                    foreach (var c in danhSach)
                    {
                        if (c.DonVi.ToLower() == "phong tai chinh" || c.DonVi.ToLower() == "phong tai chinh")
                        {
                            c.In();
                            Console.WriteLine("------------------------");
                        }
                    }
                    break;
                case 2:
                    Console.Write("\nNhap ho tên can tim: ");
                    string hoTenTim = Console.ReadLine().ToLower();
                    bool found = false;
                    foreach (var c in danhSach)
                    {
                        if (c.HoTen.ToLower().Contains(hoTenTim))
                        {
                            c.In();
                            Console.WriteLine("------------------------");
                            found = true;
                        }
                    }
                    if (!found)
                        Console.WriteLine("Không tim thay ca nhân nao.");
                    break;
                case 3:
                    Console.WriteLine("Thoat chương trinh.");
                    break;
                default:
                    Console.WriteLine("Chon sai. Vui long chon lai.");
                    break;
            }
        } while (chon != 3);
    }
}

