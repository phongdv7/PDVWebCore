using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PDVWebCore.Areas.Admin.Models.Home
{
    public class LoginModel
    {
        [Display(Name = "Tài khoản")]
        [Key]
        [Required(ErrorMessage = "Chưa nhập Tài khoản")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Chưa nhập mật khẩu")]
        public string Password { get; set; }

        [Display(Name = "Duy trì đăng nhập")]
        public bool RememberMe { get; set; }

        public bool DisplayCaptcha { get; set; }
    }
}