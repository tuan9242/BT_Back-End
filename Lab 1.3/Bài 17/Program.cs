// Bài 17: Mỗi một điểm trong mặt phẳng được xác đinh duy nhất bởi hai giá trị là hoành độ và tung độ.
//      1.Hãy xây dựng lớp Diem cùng với chứa các đối tượng diểm trong mặt phẳng và xây dựng
//      phương thức sau:
//          -Toán tử tạo lập
//          - Phương thức in một đối tượng thuộc lớp Diem
//          - Tính khoảng cách giữa hai điểm
//      2. Xây dựng lớp HinhTron chứa các đối tượng là các hình tròn với 2 thuộc tính là 1 đối tượng thuộc lớp Diem để xác định tâm của hình tròn một giá trị nguyên để xác định bán kính của hình tròn.
//      Cài đặt các phương thức:
//          -Xây dựng các toán tử tạo lập: HinhTron(),
//          -HinhTron(Diem d, float bk)
//          - Tính chu vi, diện tich hình tròn;
//          -Nhập vào một danh sách các hình tròn, hiển thị thông tin về hình tròn giao với nhiều hình tròn khác nhất trong danh sách những hình tròn đã nhập vào.

using System;
using System.Collections.Generic;

class Diem
{
    public float x, y;

    public Diem() { x = 0; y = 0; }

    public Diem(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public void InDiem()
    {
        Console.WriteLine($"({x}, {y})");
    }

    public double KhoangCach(Diem d)
    {
        return Math.Sqrt(Math.Pow(x - d.x, 2) + Math.Pow(y - d.y, 2));
    }
}

class HinhTron
{
    public Diem tam;
    public float banKinh;

    public HinhTron()
    {
        tam = new Diem();
        banKinh = 1;
    }

    public HinhTron(Diem d, float bk)
    {
        tam = d;
        banKinh = bk;
    }

    public double ChuVi()
    {
        return 2 * Math.PI * banKinh;
    }

    public double DienTich()
    {
        return Math.PI * banKinh * banKinh;
    }

    public void InThongTin()
    {
        Console.Write("Tâm: ");
        tam.InDiem();
        Console.WriteLine($"Ban kinh: {banKinh}");
        Console.WriteLine($"Chu vi: {ChuVi():F2}");
        Console.WriteLine($"Dien tích: {DienTich():F2}");
    }

    public bool GiaoNhau(HinhTron ht)
    {
        double kc = tam.KhoangCach(ht.tam);
        return kc <= (banKinh + ht.banKinh) && kc >= Math.Abs(banKinh - ht.banKinh);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Nhap so lưong hinh tron: ");
        int n = int.Parse(Console.ReadLine());

        List<HinhTron> danhSach = new List<HinhTron>();

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Nhap hinh tron thu {i + 1}:");
            Console.Write("Hoanh đo tâm: ");
            float x = float.Parse(Console.ReadLine());
            Console.Write("Tung đo tâm: ");
            float y = float.Parse(Console.ReadLine());
            Console.Write("Ban kinh: ");
            float bk = float.Parse(Console.ReadLine());

            danhSach.Add(new HinhTron(new Diem(x, y), bk));
        }

        int maxGiao = -1;
        int chiSo = -1;

        for (int i = 0; i < danhSach.Count; i++)
        {
            int dem = 0;
            for (int j = 0; j < danhSach.Count; j++)
            {
                if (i != j && danhSach[i].GiaoNhau(danhSach[j]))
                    dem++;
            }

            if (dem > maxGiao)
            {
                maxGiao = dem;
                chiSo = i;
            }
        }

        Console.WriteLine("\nHinh tron giao voi nhieu hinh tron khac nhat:");
        danhSach[chiSo].InThongTin();
    }
}
