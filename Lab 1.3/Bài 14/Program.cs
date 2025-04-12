// Bài 14: Lớp PhanSo có các thuộc tính riêng gồm: tuSo, mauSo, Hãy:
//      1.Xây dựng các toán tử tạo lập : PhanSo(), PhanSo(int tu, int mau)
//      2.Xây dựng các phương thức:
//          +Nhập vào một phân số
//          + Hiển thị một phân số
//          + Rút gọn một phân số
//          + Cộng hai phân số
//          + Trừ hai phân số
//          + Chia hai phân số
//      3. Cài đặt chương trình thực hiện: Nhập vào hai phân số A và B, sau đó tính thực hiện các yêu cầu của người dùng
//          +hiển thị kết quả ra màn hình.

using System;
class PhanSo
{
    private int tuSo;
    private int mauSo;

    // Toán tử tạo lập không đối số
    public PhanSo()
    {
        tuSo = 0;
        mauSo = 1;
    }

    // Toán tử tạo lập có đối số
    public PhanSo(int tu, int mau)
    {
        tuSo = tu;
        mauSo = mau != 0 ? mau : 1; 
        RutGon();
    }

    public void Nhap()
    {
        Console.Write("Nhap tu so: ");
        tuSo = int.Parse(Console.ReadLine());

        do
        {
            Console.Write("Nhap mau so (khac 0): ");
            mauSo = int.Parse(Console.ReadLine());
        } while (mauSo == 0);

        RutGon();
    }

    public void HienThi()
    {
        if (mauSo == 1)
            Console.WriteLine(tuSo);
        else
            Console.WriteLine($"{tuSo}/{mauSo}");
    }

    // Rút gọn phân số
    private int UCLN(int a, int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);
        while (b != 0)
        {
            int temp = a % b;
            a = b;
            b = temp;
        }
        return a;
    }
    public void RutGon()
    {
        int ucln = UCLN(tuSo, mauSo);
        tuSo /= ucln;
        mauSo /= ucln;

        // Nếu mẫu số âm thì đưa dấu trừ lên tử
        if (mauSo < 0)
        {
            tuSo = -tuSo;
            mauSo = -mauSo;
        }
    }

    // Cộng phân số
    public PhanSo Cong(PhanSo p)
    {
        int tu = tuSo * p.mauSo + p.tuSo * mauSo;
        int mau = mauSo * p.mauSo;
        return new PhanSo(tu, mau);
    }

    // Trừ phân số
    public PhanSo Tru(PhanSo p)
    {
        int tu = tuSo * p.mauSo - p.tuSo * mauSo;
        int mau = mauSo * p.mauSo;
        return new PhanSo(tu, mau);
    }

    // Chia phân số
    public PhanSo Chia(PhanSo p)
    {
        int tu = tuSo * p.mauSo;
        int mau = mauSo * p.tuSo;
        return new PhanSo(tu, mau);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Nhap phan so A:");
        PhanSo A = new PhanSo();
        A.Nhap();

        Console.WriteLine("Nhap phan so B:");
        PhanSo B = new PhanSo();
        B.Nhap();

        Console.WriteLine("\nPhân so A: ");
        A.HienThi();

        Console.WriteLine("Phân so B: ");
        B.HienThi();

        Console.WriteLine("\nKet qua cac phep toan:");

        PhanSo tong = A.Cong(B);
        Console.Write("A + B = ");
        tong.HienThi();

        PhanSo hieu = A.Tru(B);
        Console.Write("A - B = ");
        hieu.HienThi();

        PhanSo thuong = A.Chia(B);
        Console.Write("A / B = ");
        thuong.HienThi();

        Console.ReadLine();
    }
}
