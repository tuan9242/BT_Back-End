// Bài 15:
//      1. Hãy xây dựng lớp DaGiac gồm có các thuộc tính
//          -Số cạnh của đa giác
//          - Mảng các số nguyên chứa kích thước các cạnh của đa giác
//      Các phương thức:
//          -Tính chu vi
//          - In giá trị các cạnh của đa giác.
//      2. Xây dựng lớp TamGiac kế thừa từ lớp DaGiac, trong đó viết đè hàm tính chu vi và xây dựng thêm phương thức tính diện tích tam giác
//      3. Xây dựng một ứng dụng để nhập vào một dãy gồm n tam giác rồi in ra màn hình các cạnh của các tam giác thỏa mãn định lý Pitago.

using System;
class DaGiac
{
    protected int soCanh;
    protected int[] kichThuoc;

    public DaGiac()
    {
        soCanh = 0;
        kichThuoc = new int[0];
    }

    public DaGiac(int soCanh, int[] kichThuoc)
    {
        this.soCanh = soCanh;
        this.kichThuoc = new int[soCanh];
        for (int i = 0; i < soCanh; i++)
        {
            this.kichThuoc[i] = kichThuoc[i];
        }
    }

    public virtual int TinhChuVi()
    {
        int chuVi = 0;
        foreach (int canh in kichThuoc)
        {
            chuVi += canh;
        }
        return chuVi;
    }

    public void InCacCanh()
    {
        Console.Write("Cac canh: ");
        foreach (int canh in kichThuoc)
        {
            Console.Write(canh + " ");
        }
        Console.WriteLine();
    }
}
class TamGiac : DaGiac
{
    public TamGiac(int[] kichThuoc) : base(3, kichThuoc)
    {
    }

    public override int TinhChuVi()
    {
        return kichThuoc[0] + kichThuoc[1] + kichThuoc[2];
    }

    public double TinhDienTich()
    {
        double p = TinhChuVi() / 2.0;
        double a = kichThuoc[0];
        double b = kichThuoc[1];
        double c = kichThuoc[2];

        // Công thức Heron
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c)); 
    }

    public bool LaTamGiacVuong()
    {
        // sắp xếp tăng dần
        Array.Sort(kichThuoc); 
        int a = kichThuoc[0];
        int b = kichThuoc[1];
        int c = kichThuoc[2];
        return c * c == a * a + b * b;
    }
}
class Program
{
    static void Main()
    {
        Console.Write("Nhap so lưong tam giac: ");
        int n = int.Parse(Console.ReadLine());

        TamGiac[] dsTamGiac = new TamGiac[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nNhap tam giac thu {i + 1}:");
            int[] canh = new int[3];

            for (int j = 0; j < 3; j++)
            {
                Console.Write($"Canh {j + 1}: ");
                canh[j] = int.Parse(Console.ReadLine());
            }

            dsTamGiac[i] = new TamGiac(canh);
        }

        Console.WriteLine("\nCac tam giac thoa đinh ly Pitago (tam giac vuông):");
        foreach (var tg in dsTamGiac)
        {
            if (tg.LaTamGiacVuong())
            {
                tg.InCacCanh();
                Console.WriteLine("-> La tam giac vuông");
                Console.WriteLine($"   Chu vi: {tg.TinhChuVi()}");
                Console.WriteLine($"   Dien tich: {tg.TinhDienTich():0.00}\n");
            }
        }

        Console.ReadLine();
    }
}
