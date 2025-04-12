// Bài 11: Xây dựng lớp SoPhuc có các thuộc tính riêng gồm: phanThuc, phanAo kiểu double
//      1.Xây dựng các hàm tạo như sau: SoPhuc(), SoPhuc(double a, double b)
//      2.Xây dựng các phương thức:+Nhập vào một số phức
//          + Hiển thị một số phức
//          + Cộng hai số phức.
//          + Nhân hai số phức
//          + Chia hai số phức.
//      3. Cài đặt chương trình thực hiện : Nhập vào hai số phức A và B, sau đó hỏi người dùng muốn thực hiện tác vụ nào:
//          a) Tính tổng hai số phức;
//          b) Tính hiệu hai số phức;
//          c) Tính tích hai số phức;
//          d) Tính thương hai số phức;
//      Rồi hiển thị kết quả ra màn hình

using System;

class SoPhuc
{
    public double PhanThuc { get; set; }
    public double PhanAo { get; set; }

    public SoPhuc()
    {
        PhanThuc = 0;
        PhanAo = 0;
    }

    public SoPhuc(double a, double b)
    {
        PhanThuc = a;
        PhanAo = b;
    }

    public void NhapSoPhuc()
    {
        Console.Write("Nhap phan thuc: ");
        PhanThuc = double.Parse(Console.ReadLine());
        Console.Write("Nhap phan ao: ");
        PhanAo = double.Parse(Console.ReadLine());
    }

    public void HienThiSoPhuc()
    {
        Console.WriteLine($"So phuc: {PhanThuc} + {PhanAo}i");
    }

    // Cộng 2 số phức
    public SoPhuc Cong(SoPhuc sp)
    {
        return new SoPhuc(PhanThuc + sp.PhanThuc, PhanAo + sp.PhanAo);
    }

    // Nhân 2 số phức
    public SoPhuc Nhan(SoPhuc sp)
    {
        double real = PhanThuc * sp.PhanThuc - PhanAo * sp.PhanAo;
        double imag = PhanThuc * sp.PhanAo + PhanAo * sp.PhanThuc;
        return new SoPhuc(real, imag);
    }

    // Chia 2 số phức
    public SoPhuc Chia(SoPhuc sp)
    {
        double denominator = sp.PhanThuc * sp.PhanThuc + sp.PhanAo * sp.PhanAo;
        double real = (PhanThuc * sp.PhanThuc + PhanAo * sp.PhanAo) / denominator;
        double imag = (PhanAo * sp.PhanThuc - PhanThuc * sp.PhanAo) / denominator;
        return new SoPhuc(real, imag);
    }
}

class Program
{
    static void Main()
    {
        SoPhuc A = new SoPhuc();
        SoPhuc B = new SoPhuc();

        Console.WriteLine("Nhap so phuc A:");
        A.NhapSoPhuc();
        Console.WriteLine("Nhap so phuc B:");
        B.NhapSoPhuc();

        Console.WriteLine("Chon tac vu:");
        Console.WriteLine("a) Tinh tong hai so phuc");
        Console.WriteLine("b) Tinh hieu hai so phuc");
        Console.WriteLine("c) Tinh tich hai so phuc");
        Console.WriteLine("d) Tinh thương hai so phuc");
        char chon = char.Parse(Console.ReadLine());

        SoPhuc result = null;
        switch (chon)
        {
            case 'a':
                result = A.Cong(B);
                Console.WriteLine("Tong cua A và B: ");
                break;
            case 'b':
                result = new SoPhuc(A.PhanThuc - B.PhanThuc, A.PhanAo - B.PhanAo);
                Console.WriteLine("Hieu cua A và B: ");
                break;
            case 'c':
                result = A.Nhan(B);
                Console.WriteLine("Tich cua A và B: ");
                break;
            case 'd':
                result = A.Chia(B);
                Console.WriteLine("Thương cua A và B: ");
                break;
            default:
                Console.WriteLine("Chon không hop le");
                break;
        }

        if (result != null)
        {
            result.HienThiSoPhuc();
        }
    }
}
