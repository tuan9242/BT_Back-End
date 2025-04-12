// Bài 16: Mỗi một điểm trong mặt phẳng được xác đinh duy nhất bởi hai giá trị là hoành độ và tung độ.
//      1.Hãy xây dựng lớp Diem cùng với chứa các đối tượng điểm trong mặt phẳng và xây dựng
//      phương thức sau:
//          -Toán tử tạo lập
//          - Phương thức in một đối tượng Diem
//          - Tính khoảng cách giữa hai điểm
//      2. Mỗi tam giác trong mặt phẳng được xác định bởi 3 điểm. Hãy xây dựng lớp TamGiac với 3 thuộc tính riêng là 3 đối tượng thuộc lớp Diem và các phương thức:
//          -Xây dựng các toản tử tạo lập: TamGiac(); TamGiac(Diem d1, Diem d2, Diem d3);
//          -Tính diện tích tam giác
//          - Tính chu vi của tam giác
//      3. Nhập vào một danh sách các tam giác, đưa ra tổng chu vi và tổng diện tích của các tam giác vừa nhập.

using System;
using System.Collections.Generic;

public class Diem
{
    public double X { get; set; }
    public double Y { get; set; }
    public Diem()
    {
        X = 0;
        Y = 0;
    }
    public Diem(double x, double y)
    {
        X = x;
        Y = y;
    }
    public void InDiem()
    {
        Console.WriteLine($"({X}, {Y})");
    }
    public double TinhKhoangCach(Diem d)
    {
        return Math.Sqrt((X - d.X) * (X - d.X) + (Y - d.Y) * (Y - d.Y));
    }
}
public class TamGiac
{
    private Diem A;
    private Diem B;
    private Diem C;
    public TamGiac()
    {
        A = new Diem();
        B = new Diem();
        C = new Diem();
    }
    public TamGiac(Diem d1, Diem d2, Diem d3)
    {
        A = d1;
        B = d2;
        C = d3;
    }
    private double CanhAB() => A.TinhKhoangCach(B);
    private double CanhBC() => B.TinhKhoangCach(C);
    private double CanhCA() => C.TinhKhoangCach(A);

    // Tính chu vi tam giác
    public double TinhChuVi()
    {
        return CanhAB() + CanhBC() + CanhCA();
    }

    // Tính diện tích tam giác (công thức Heron)
    public double TinhDienTich()
    {
        double a = CanhAB();
        double b = CanhBC();
        double c = CanhCA();
        double p = (a + b + c) / 2;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }
}
class Program
{
    static void Main()
    {
        Console.Write("Nhap so lưong tam giac: ");
        int n = int.Parse(Console.ReadLine());

        List<TamGiac> danhSachTamGiac = new List<TamGiac>();

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nNhap tam giac thứ {i + 1}:");

            Console.Write("Nhap hoanh đo va tung đo cua điem A: ");
            string[] a = Console.ReadLine().Split();
            Diem A = new Diem(double.Parse(a[0]), double.Parse(a[1]));


            Console.Write("Nhap hoanh đo va tung đo cua điem B: ");
            string[] b = Console.ReadLine().Split();
            Diem B = new Diem(double.Parse(b[0]), double.Parse(b[1]));

            Console.Write("Nhap hoanh đo va tung đo cua điem C: ");
            string[] c = Console.ReadLine().Split();
            Diem C = new Diem(double.Parse(c[0]), double.Parse(c[1]));

            TamGiac tg = new TamGiac(A, B, C);
            danhSachTamGiac.Add(tg);
        }

        double tongChuVi = 0;
        double tongDienTich = 0;

        foreach (var tg in danhSachTamGiac)
        {
            tongChuVi += tg.TinhChuVi();
            tongDienTich += tg.TinhDienTich();
        }

        Console.WriteLine($"\nTong chu vi cac tam giac: {tongChuVi:F2}");
        Console.WriteLine($"Tong dien tich cac tam giac: {tongDienTich:F2}");
    }
}

