// Bài 12: Xây dựng lớp MaTran có các thuộc tính riêng như sau:
//      +Số dòng, số cột của ma trận
//      + Một mảng hai chiều để lưu trữ các phần tử của ma trận Hãy:
//  1.Xây dựng các hàm tạo : MaTran(), maTran(int n, int m); (Toán tử tạo lập thứ hai để tạo ra ma trận có n dòng và m cột)
//  2. Xây dựng các phương thức: Nhập vào và hiển thị một ma trận
//  3. Xây dựng các phương thức tính tổng, hiệu và tích, thương của hai ma trận
//  4. Cài đặt chương trình thực hiện : Nhập vào hai ma trận A và B cùng cấp, sau đó hỏi người dùng muốn thực hiện tác vụ nào:
//      a) Tính tổng hai ma trận;
//      b) Tính tích hai ma trận;
//      c) Tính hiệu hai ma trận;
//      d) Tính thương hai ma trận
//  Hiển thị kết quả ra màn hình.

using System;

class MaTran
{
    private int soDong;
    private int soCot;
    private double[,] duLieu;

    public MaTran()
    {
        soDong = 0;
        soCot = 0;
        duLieu = new double[0, 0];
    }

    public MaTran(int n, int m)
    {
        soDong = n;
        soCot = m;
        duLieu = new double[n, m];
    }

    public void Nhap()
    {
        Console.WriteLine($"Nhap ma tran kich thưoc {soDong}x{soCot}:");
        for (int i = 0; i < soDong; i++)
        {
            for (int j = 0; j < soCot; j++)
            {
                Console.Write($"Phan tu [{i},{j}]: ");
                duLieu[i, j] = double.Parse(Console.ReadLine());
            }
        }
    }

    public void HienThi()
    {
        for (int i = 0; i < soDong; i++)
        {
            for (int j = 0; j < soCot; j++)
            {
                Console.Write(duLieu[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    // Tổng hai ma trận
    public MaTran Tong(MaTran b)
    {
        MaTran kq = new MaTran(soDong, soCot);
        for (int i = 0; i < soDong; i++)
            for (int j = 0; j < soCot; j++)
                kq.duLieu[i, j] = this.duLieu[i, j] + b.duLieu[i, j];
        return kq;
    }

    // Hiệu hai ma trận
    public MaTran Hieu(MaTran b)
    {
        MaTran kq = new MaTran(soDong, soCot);
        for (int i = 0; i < soDong; i++)
            for (int j = 0; j < soCot; j++)
                kq.duLieu[i, j] = this.duLieu[i, j] - b.duLieu[i, j];
        return kq;
    }

    // Tích hai ma trận
    public MaTran Tich(MaTran b)
    {
        if (this.soCot != b.soDong)
        {
            Console.WriteLine("Không the nhân hai ma tran: so cot ma tran A phai bang so dong ma tran B.");
            return null;
        }

        MaTran kq = new MaTran(this.soDong, b.soCot);
        for (int i = 0; i < this.soDong; i++)
        {
            for (int j = 0; j < b.soCot; j++)
            {
                double sum = 0;
                for (int k = 0; k < this.soCot; k++)
                {
                    sum += this.duLieu[i, k] * b.duLieu[k, j];
                }
                kq.duLieu[i, j] = sum;
            }
        }
        return kq;
    }

    // Thương hai ma trận (chia từng phần tử)
    public MaTran Thuong(MaTran b)
    {
        MaTran kq = new MaTran(soDong, soCot);
        for (int i = 0; i < soDong; i++)
        {
            for (int j = 0; j < soCot; j++)
            {
                if (b.duLieu[i, j] != 0)
                    kq.duLieu[i, j] = this.duLieu[i, j] / b.duLieu[i, j];
                else
                {
                    Console.WriteLine($"Loi: phan tu [{i},{j}] cua ma tran B bang 0.");
                    kq.duLieu[i, j] = 0;
                }
            }
        }
        return kq;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Nhap so dong cua ma tran: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Nhap so cot của ma tran: ");
        int m = int.Parse(Console.ReadLine());

        MaTran A = new MaTran(n, m);
        MaTran B = new MaTran(n, m);

        Console.WriteLine("\nNhap ma tran A:");
        A.Nhap();

        Console.WriteLine("\nNhap ma tran B:");
        B.Nhap();

        Console.WriteLine("\nChon phep toan:");
        Console.WriteLine("a) Tinh tong hai ma tran");
        Console.WriteLine("b) Tinh tich hai ma tran");
        Console.WriteLine("c) Tinh hieu hai ma tran");
        Console.WriteLine("d) Tinh thương hai ma tran");
        Console.Write("Nhap lua chon (a/b/c/d): ");
        char luaChon = Console.ReadLine()[0];

        MaTran ketQua = null;

        switch (luaChon)
        {
            case 'a':
                ketQua = A.Tong(B);
                Console.WriteLine("\nTong hai ma tran:");
                break;
            case 'b':
                ketQua = A.Tich(B);
                Console.WriteLine("\nTich hai ma tran:");
                break;
            case 'c':
                ketQua = A.Hieu(B);
                Console.WriteLine("\nHieu hai ma tran:");
                break;
            case 'd':
                ketQua = A.Thuong(B);
                Console.WriteLine("\nThương hai ma tran:");
                break;
            default:
                Console.WriteLine("Lua chon không hop le!");
                break;
        }

        if (ketQua != null)
        {
            ketQua.HienThi();
        }
    }
}



