// Bài 1: Một đơn vị sản xuất gồm có các cán bộ là công nhân, kỹ sư, nhân viên.
// +Mỗi cán bộ cần quản lý các thuộc tính: Họ tên, năm sinh, giới tính, địa chỉ
// + Các công nhân cần quản lý: Bậc(công nhân bậc 3 / 7, bậc 4 / 7...)
// + Các kỹ sư cần quản lý: Ngành đào tạo
// + Các nhân viên phục vụ cần quản lý thông tin: công việc
// 1. Xây dựng các lớp NhanVien, CongNhan, KySu kế thừa từ lớp CanBo
// 2. Xây dựng các phương thức nhập, hiển thị thông tin và kiểm tra về các thuộc tính của các lớp.
// 3. Xây dựng lớp QLCB cài đặt các phương thức thực hiện các chức sau:
//    -Nhập thông tin mới cho cán bộ (Hỏi người dùng muốn nhập cho: công nhân, kỹ sư hay nhân viên và nhập đúng thông tin cho đối tượng đó).
//    - Tìm kiếm theo họ tên
//    - Hiển thị thông tin về danh sách các cán bộ
//    - Thoát khỏi chương trình.

using System;
using System.Collections.Generic;
class CanBo
{
    public string HoTen { get; set; }
    public int NamSinh { get; set; }
    public string GioiTinh { get; set; }
    public string DiaChi { get; set; }

    public virtual void NhapThongTin()
    {
        Console.Write("Ho ten: ");
        HoTen = Console.ReadLine();
        Console.Write("Năm sinh: ");
        NamSinh = int.Parse(Console.ReadLine());
        Console.Write("Gioi tinh: ");
        GioiTinh = Console.ReadLine();
        Console.Write("Đia chi: ");
        DiaChi = Console.ReadLine();
    }
    public virtual void HienThiThongTin()
    {
        Console.WriteLine($"Ho tên: {HoTen}, Năm sinh: {NamSinh}, Gioi tinh: {GioiTinh}, Đia chi: {DiaChi}");
    }
}
class CongNhan : CanBo
{
    public int Bac { get; set; }

    public override void NhapThongTin()
    {
        base.NhapThongTin();
        Console.Write("Bac (1-7): ");
        Bac = int.Parse(Console.ReadLine());
    }
    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Bac: {Bac}");
    }
}
class KySu : CanBo
{
    public string NganhDaoTao { get; set; }

    public override void NhapThongTin()
    {
        base.NhapThongTin();
        Console.Write("Nganh đao tao: ");
        NganhDaoTao = Console.ReadLine();
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Nganh đao tao: {NganhDaoTao}");
    }
}
class NhanVien : CanBo
{
    public string CongViec { get; set; }

    public override void NhapThongTin()
    {
        base.NhapThongTin();
        Console.Write("Công viec: ");
        CongViec = Console.ReadLine();
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Công viec: {CongViec}");
    }
}
class QLCB
{
    private List<CanBo> danhSachCanBo = new List<CanBo>();

    public void NhapCanBo()
    {
        Console.WriteLine("Nhap loai can bo (1: Công nhân, 2: Ky sư, 3: Nhân viên): ");
        int loai = int.Parse(Console.ReadLine());
        CanBo canbo;

        switch (loai)
        {
            case 1:
                canbo = new CongNhan();
                break;
            case 2:
                canbo = new KySu();
                break;
            case 3:
                canbo = new NhanVien();
                break;
            default:
                Console.WriteLine("Lua chọn không hop le!");
                return;
        }

        canbo.NhapThongTin();
        danhSachCanBo.Add(canbo);
    }
    public void TimKiemTheoHoTen()
    {
        Console.Write("Nhap họ tên can tim: ");
        string hoTen = Console.ReadLine();
        foreach (var cb in danhSachCanBo)
        {
            if (cb.HoTen.Contains(hoTen))
            {
                cb.HienThiThongTin();
            }
        }
    }

    public void HienThiDanhSach()
    {
        foreach (var cb in danhSachCanBo)
        {
            cb.HienThiThongTin();
            Console.WriteLine("------------------");
        }
    }
}

class Program
{
    static void Main()
    {
        QLCB qlcb = new QLCB();
        while (true)
        {
            Console.WriteLine("Chon chuc năng: 1. Nhap can bo | 2. Tim kiem | 3. Hien thị | 4. Thoat");
            int chon = int.Parse(Console.ReadLine());
            switch (chon)
            {
                case 1:
                    qlcb.NhapCanBo();
                    break;
                case 2:
                    qlcb.TimKiemTheoHoTen();
                    break;
                case 3:
                    qlcb.HienThiDanhSach();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Lua chon không hợp lệ!");
                    break;
            }
        }
    }
}
