using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1Lab15
{
    internal class PhanSo
    {
        public int TuSo { get; set; }
        public int MauSo { get; set; }

        public PhanSo()
        {
            TuSo = 0;
            MauSo = 1;
        }

        public PhanSo(int tu, int mau)
        {
            TuSo = tu;
            MauSo = mau == 0 ? 1 : mau; // Tránh mẫu số = 0
        }

        public void Nhap()
        {
            Console.Write("Nhập tử số: ");
            TuSo = int.Parse(Console.ReadLine());
            Console.Write("Nhập mẫu số: ");
            MauSo = int.Parse(Console.ReadLine());
            if (MauSo == 0)
            {
                Console.WriteLine("Mẫu số không được bằng 0. Đã tự động đặt mẫu số = 1.");
                MauSo = 1;
            }
        }

        public static PhanSo operator +(PhanSo a, PhanSo b)
        {
            int tu = a.TuSo * b.MauSo + b.TuSo * a.MauSo;
            int mau = a.MauSo * b.MauSo;
            return RutGon(new PhanSo(tu, mau));
        }

        public static PhanSo RutGon(PhanSo p)
        {
            int ucln = UCLN(Math.Abs(p.TuSo), Math.Abs(p.MauSo));
            p.TuSo /= ucln;
            p.MauSo /= ucln;
            // Nếu mẫu âm thì đổi dấu cả tử và mẫu
            if (p.MauSo < 0)
            {
                p.TuSo = -p.TuSo;
                p.MauSo = -p.MauSo;
            }
            return p;
        }

        private static int UCLN(int a, int b)
        {
            while (b != 0)
            {
                int temp = a % b;
                a = b;
                b = temp;
            }
            return a;
        }

        public void HienThi()
        {
            if (MauSo == 1)
                Console.WriteLine($"{TuSo}");
            else
                Console.WriteLine($"{TuSo}/{MauSo}");
        }
    }
}
