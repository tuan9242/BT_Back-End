using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai2Lab15
{
    internal class HinhTron : Hinh
    {
        public double BanKinh { get; set; }

        public HinhTron(double banKinh)
        {
            BanKinh = banKinh;
        }

        public override double TinhChuVi()
        {
            return 2 * Math.PI * BanKinh;
        }

        public override double TinhDienTich()
        {
            return Math.PI * BanKinh * BanKinh;
        }
    }
}
