using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1Lab15
{
    internal class main
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Nhập số lượng phân số: ");
            int n = int.Parse(Console.ReadLine());
            List<PhanSo> danhSach = new List<PhanSo>();

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n-- Nhập phân số thứ {i + 1} --");
                PhanSo p = new PhanSo();
                p.Nhap();
                danhSach.Add(p);
            }

            PhanSo tong = new PhanSo(0, 1);
            foreach (var p in danhSach)
            {
                tong += p;
            }

            Console.WriteLine("\nTổng các phân số là:");
            tong.HienThi();
        }
    }
}
