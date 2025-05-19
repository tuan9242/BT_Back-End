using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai2Lab15
{
    internal class HinhTamGiac : Hinh
    {
        public double CanhA { get; set; }
        public double CanhB { get; set; }
        public double CanhC { get; set; }

        public HinhTamGiac(double a, double b, double c)
        {
            CanhA = a;
            CanhB = b;
            CanhC = c;
        }

        public override double TinhChuVi()
        {
            return CanhA + CanhB + CanhC;
        }

        public override double TinhDienTich()
        {
            double p = TinhChuVi() / 2;
            return Math.Sqrt(p * (p - CanhA) * (p - CanhB) * (p - CanhC)); // Công thức Heron
        }
    }
}
