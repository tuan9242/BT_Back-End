using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai2Lab15
{
    internal class HinhChuNhat : Hinh
    {
        public double ChieuDai { get; set; }
        public double ChieuRong { get; set; }

        public HinhChuNhat(double chieuDai, double chieuRong)
        {
            ChieuDai = chieuDai;
            ChieuRong = chieuRong;
        }

        public override double TinhChuVi()
        {
            return 2 * (ChieuDai + ChieuRong);
        }

        public override double TinhDienTich()
        {
            return ChieuDai * ChieuRong;
        }
    }
}
