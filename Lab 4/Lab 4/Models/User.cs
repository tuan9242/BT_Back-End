using System.ComponentModel.DataAnnotations;

namespace Lab_4.Models
{
    public class User
    {
        [Required(ErrorMessage = "Không được để trống!")]
        [Display(Name = "Mã sinh viên")]
        public string? Id { get; set; }

        [Display(Name = "Tài khoản")]
        [Required(ErrorMessage = "Không được để trống!")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Tài khoản từ 6 - 20 ký tự")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Không được để trống!")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "Mật khẩu từ 6 - 10 ký tự")]
        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Không được để trống!")]
        [EmailAddress(ErrorMessage = "Sai định dạng email")]
        public string? Email { get; set; }

        [Display(Name = "Điện thoại")]
        [Required(ErrorMessage = "Không được để trống!")]
        [Phone(ErrorMessage = "Sai định dạng số điện thoại")]
        public string? Phone { get; set; }
    }

}

