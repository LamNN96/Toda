using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TodaSupportWeb.Models
{
    public class LoginViewModels
    {
        [Required(ErrorMessage = "Bạn phải nhập tên đăng nhập")]
        [StringLength(30)]
        [Display(Name = "Tài khoản: ")]
        public string Username { get; set; }


        [Required(ErrorMessage = "Bạn phải nhập mật khẩu")]
        [StringLength(50)]
        [Display(Name = "Mật khẩu: ")]
        public string Password { get; set; }
    }
}