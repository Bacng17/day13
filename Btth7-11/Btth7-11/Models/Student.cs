using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Btth7_11.Models
{
    public class Student 
    {
        public int Id { get; set; }  // Mã sinh viên

        [Required(ErrorMessage = "Họ tên không được để trống")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Họ tên phải từ 4 đến 100 ký tự")]
        public string Name { get; set; }  // Họ tên


        [Required(ErrorMessage = "Email bắt buộc phải được nhập")]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@gmail\.com$",
            ErrorMessage = "Email phải có định dạng hợp lệ và phải dùng đuôi @gmail.com")]
        public string Email { get; set; }  // Email


        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Mật khẩu phải từ 8 ký tự trở lên")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W).+$",
            ErrorMessage = "Mật khẩu phải gồm chữ hoa, chữ thường, chữ số và ký tự đặc biệt")]
        public string Password { get; set; }  // Mật khẩu


        [Required(ErrorMessage = "Ngành học không được để trống")]
        public Branch? Branch { get; set; }  // Ngành học


        [Required(ErrorMessage = "Giới tính không được để trống")]
        public Gender? Gender { get; set; }  // Giới tính


        public bool IsRegular { get; set; }  // Hệ


        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }  // Địa chỉ

        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        [Range(typeof(DateTime), "1963-01-01", "2005-12-31",
            ErrorMessage = "Ngày sinh phải từ năm 1963 đến 2005")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }



        [Required(ErrorMessage = "Điểm số không được để trống")]
        [Range(0.0, 10.0, ErrorMessage = "Điểm phải từ 0 đến 10")]
        public double Score { get; set; }  // Điểm số
        public IFormFile? Avatar { get; set; } // Ảnh đại diện
        public string? AvatarPath { get; set; } // Đường dẫn lưu ảnh

    }

}
