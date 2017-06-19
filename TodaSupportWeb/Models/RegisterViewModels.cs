using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TodaSupportWeb.Models
{
    public class RegisterViewModels
    {
        [Display(Name = "Email: ")]
        [Required(ErrorMessage ="Email không được để trống")]
        public string Email { get; set; }

        [Display(Name = "Tài khoản: ")]
        [Required(ErrorMessage = "Tài khoản không được để trống")]
        public string Username { get; set; }



        [Display(Name = "Mật khẩu: ")]
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [StringLength(20,ErrorMessage ="Độ dài mật khẩu phải từ 6 đến 20 ký tự", MinimumLength =6) ]
        public string Password { get; set; }

        [Display(Name = "Xác nhận mật khẩu: ")]
        [Compare("Password",ErrorMessage ="Mật khẩu xác nhận không khớp")]
        public string  ConfirmPassword { get; set; }

        [Display(Name = "Tên: ")]
        [Required(ErrorMessage = "Tên không được để trống")]
        public string Name { get; set; }

        [Display(Name = "Số điện thoại: ")]
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        public string PhoneNumber { get; set; }
    }
}