using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class RegisterModel
    {
        [Key]
        public long ID { set; get; }

        [Display(Name=" Tên đăng nhập")]
        [Required(ErrorMessage ="Yêu cầu đăng nhập tên đăng nhập")]
      
        public string UserName { set; get; }
        [Display(Name = " Mật khẩu")]
        [StringLength(maximumLength:20,MinimumLength =6,ErrorMessage ="Đô dài mật khẩu phải có ít nhất 6 kí tự .")]
        [Required(ErrorMessage ="Yêu cầu nhập mật khẩu")]
        public string Password { set; get; }

        [Display(Name = " Xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage ="Xác nhận mật khẩu không đúng")]
        public string ConfirmPassword { set; get; }

        [Display(Name = " Họ tên")]
        [Required(ErrorMessage = "Yêu cầu nhập họ tên")]
        public string Name { set; get; }

        [Display(Name = " Địa chỉ")]
        public string Address { set; get; }

        [Display(Name = " Email")]
        [Required(ErrorMessage = "Yêu cầu nhập email")]
        public string Email { set; get; }

        [Display(Name = "Điện thoại")]
        [Required(ErrorMessage = "Yêu cầu nhập điện thoại")]
        public string Phone { set; get; }
    }
}