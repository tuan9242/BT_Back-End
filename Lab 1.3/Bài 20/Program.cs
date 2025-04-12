// Bài 20: Một hội quản lý hội viên của mình như sau: Mỗi hội viên có hai thông tin chung là họ tên, địa chỉ. Ai đã có gia đình thì khai thêm họ tên vợ và ngày cưới.
// Ai đã có người yêu thìkhai thêm họ tên và số điện thoại của người yêu.
// Ai chưa có người yêu thì không khai thêm gì cả.
//1. Hãy xây dựng các lớp sao cho việc kế thừa được sử dụng lại nhiều nhất.
//2. Nhập danh sách cho N hội viên (N nhập vào từ bàn phím)
//3. Tìm kiếm thông tin của những hội viên có ngày cưới là: 11.11.2011.
//4.Hiển thị thông tin cho những người đã có người yêu nhưng chưa lập gia đình.

using System;
using System.Collections.Generic;
class HoiVien
{
    public string HoTen;
    public string DiaChi;

    public HoiVien(string hoTen, string diaChi)
    {
        HoTen = hoTen;
        DiaChi = diaChi;
    }

    public virtual void InThongTin()
    {
        Console.WriteLine($"Ho tên: {HoTen}");
        Console.WriteLine($"Đia chi: {DiaChi}");
    }

    public virtual bool DaCuoi => false;
    public virtual DateTime? NgayCuoi => null;
    public virtual bool CoNguoiYeu => false;
}

class HoiVienDaCuoi : HoiVien
{
    public string TenVoChong;
    public DateTime NgayCuoiValue;

    public HoiVienDaCuoi(string hoTen, string diaChi, string tenVoChong, DateTime ngayCuoi)
        : base(hoTen, diaChi)
    {
        TenVoChong = tenVoChong;
        NgayCuoiValue = ngayCuoi;
    }

    public override bool DaCuoi => true;
    public override DateTime? NgayCuoi => NgayCuoiValue;

    public override void InThongTin()
    {
        base.InThongTin();
        Console.WriteLine($"Tên vo/chong: {TenVoChong}");
        Console.WriteLine($"Ngay cưoi: {NgayCuoiValue.ToString("dd.MM.yyyy")}");
    }
}

class HoiVienCoNguoiYeu : HoiVien
{
    public string TenNguoiYeu;
    public string SoDienThoai;

    public HoiVienCoNguoiYeu(string hoTen, string diaChi, string tenNguoiYeu, string sdt)
        : base(hoTen, diaChi)
    {
        TenNguoiYeu = tenNguoiYeu;
        SoDienThoai = sdt;
    }

    public override bool CoNguoiYeu => true;

    public override void InThongTin()
    {
        base.InThongTin();
        Console.WriteLine($"Tên ngưoi yêu: {TenNguoiYeu}");
        Console.WriteLine($"SĐT ngưoi yêu: {SoDienThoai}");
    }
}

class Program
{
    static void Main()
    {
        List<HoiVien> danhSach = new List<HoiVien>();

        Console.Write("Nhap so lưong hoi viên: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\n--- Nhap hoi viên thu {i + 1} ---");

            Console.Write("Ho tên: ");
            string hoTen = Console.ReadLine();

            Console.Write("Đia chi: ");
            string diaChi = Console.ReadLine();

            Console.Write("Tinh trang (1. Đa cưoi | 2. Có ngưoi yêu | 3. Đoc thân): ");
            int loai = int.Parse(Console.ReadLine());

            if (loai == 1)
            {
                Console.Write("Tên vo/chong: ");
                string tenVo = Console.ReadLine();

                Console.Write("Ngay cưoi (dd.MM.yyyy): ");
                DateTime ngayCuoi = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", null);

                danhSach.Add(new HoiVienDaCuoi(hoTen, diaChi, tenVo, ngayCuoi));
            }
            else if (loai == 2)
            {
                Console.Write("Ten ngưoi yêu: ");
                string tenNY = Console.ReadLine();

                Console.Write("SĐT người yêu: ");
                string sdt = Console.ReadLine();

                danhSach.Add(new HoiVienCoNguoiYeu(hoTen, diaChi, tenNY, sdt));
            }
            else
            {
                danhSach.Add(new HoiVien(hoTen, diaChi));
            }
        }

        // 3. Tìm hội viên có ngày cưới là 11.11.2011
        Console.WriteLine("\n=== Hoi viên co ngay cưoi là 11.11.2011 ===");
        DateTime ngayDacBiet = DateTime.ParseExact("11.11.2011", "dd.MM.yyyy", null);
        foreach (var hv in danhSach)
        {
            if (hv.DaCuoi && hv.NgayCuoi == ngayDacBiet)
            {
                hv.InThongTin();
                Console.WriteLine("-----------------------");
            }
        }

        // 4. Hiển thị thông tin người có người yêu nhưng chưa cưới
        Console.WriteLine("\n=== Hoi viên co ngưoi yêu nhưng chưa lập gia đình ===");
        foreach (var hv in danhSach)
        {
            if (hv.CoNguoiYeu && !hv.DaCuoi)
            {
                hv.InThongTin();
                Console.WriteLine("-----------------------");
            }
        }
    }
}
