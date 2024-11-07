using System.ComponentModel.DataAnnotations;

namespace NguyenMinhHiep220900100project2.Models
{
    public class AccountViewModel
    {
        [Required(ErrorMessage = "Tên đăng nhập là bắt buộc.")]
        public string TenDangNhap { get; set; }

        [Required(ErrorMessage = "Mật khẩu là bắt buộc.")]
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }

        [Required(ErrorMessage = "Mật khẩu xác nhận là bắt buộc.")]
        [DataType(DataType.Password)]
        [Compare("MatKhau", ErrorMessage = "Mật khẩu và mật khẩu xác nhận không khớp.")]
        public string MatKhauXacNhan { get; set; } // Thêm thuộc tính này
    }
}
