// sử dụng toán tử hợp nhất
int? x = null;
int y = x ?? 10; // nếu x là null thì y sẽ bằng 10

// khai báo biến
string? ten;
int tuoi; 
// nhập dữ liệu từ bàn phím
Console.Write("Nhập tên: ");
ten = Console.ReadLine();
Console.Write("Nhập tuổi: ");
string tuoiString = Console.ReadLine();
tuoi = int.Parse(tuoiString ?? "0"); // sử dụng toán tử hợp nhất để đảm bảo không xảy ra lỗi nếu người dùng không nhập gì
// xuất ra màn hình
Console.WriteLine("Tên: {0}, Tuổi: {1}", ten, tuoi);
