// Bài 10: Để xử lý các văn bản, người ta xây dựng lớp VanBan có thuộc tính riêng là một xâu ký tự. Hãy:
//          1.Xây dựng các hàm tạo không có và có đối số như sau: VanBan(), VanBan(String st).
//          2.Xây dựng phương thức đếm số từ của một xâu.
//          3. Xây dựng phương thức đếm số ký tự H (không phân biệt chữ thường, chữ hoa) của xâu.
//          4. Chuẩn hoá một xâu theo tiêu chuẩn (Ở đầu và cuối của xâu không có ký tự trống, ở giữa xâu không có hai ký tự trắng liền nhau).
//          5. Xây dựng một menu hỏi người sử dụng muốn thực hiện công việc gì (đếm từ, đếm số kí tự H hãy chuẩn hóa sâu).
//          Sau đó hiển thị kết quả ra màn hình.

using System;
using System.Text.RegularExpressions;

class VanBan
{
    public string NoiDung { get; set; }

    public VanBan()
    {
        NoiDung = "";
    }

    public VanBan(string st)
    {
        NoiDung = st;
    }

    public int DemSoTu()
    {
        if (string.IsNullOrWhiteSpace(NoiDung)) return 0;
        return NoiDung.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
    }

    public int DemSoKyTuH()
    {
        return Regex.Matches(NoiDung, "[hH]").Count;
    }

    public void ChuanHoa()
    {
        NoiDung = Regex.Replace(NoiDung.Trim(), "\\s+", " ");
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Nhap văn ban: ");
        string input = Console.ReadLine();
        VanBan vb = new VanBan(input);

        while (true)
        {
            Console.WriteLine("\nChon chuc năng: 1. Đem so tu | 2. Đem so ky tu 'H' | 3. Chuan hoa | 4. Thoat");
            int chon = int.Parse(Console.ReadLine());
            switch (chon)
            {
                case 1:
                    Console.WriteLine($"So tu trong văn ban: {vb.DemSoTu()}");
                    break;
                case 2:
                    Console.WriteLine($"So ky tu 'H' trong văn ban: {vb.DemSoKyTuH()}");
                    break;
                case 3:
                    vb.ChuanHoa();
                    Console.WriteLine($"Văn ban sau khi chuan hoa: {vb.NoiDung}");
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Lua chon không hop le!");
                    break;
            }
        }
    }
}