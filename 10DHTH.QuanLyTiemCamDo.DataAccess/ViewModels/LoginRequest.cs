using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _10DHTH.QuanLyTiemCamDo.DataAccess.ViewModels
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Email is required!")]
        [Display(Name = "Email")]
        //[DataType(DataType.EmailAddress)]
        [RegularExpression("^\\w+@[a-zA-Z]+?\\.[a-zA-Z]{2,}$", ErrorMessage = "Email is invalid.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        [Display(Name = "Password")]
        [RegularExpression("^([a-zA-Z0-9@*#]{8,15})$", ErrorMessage = "Password must has at least 8 characters that include at least 1 lowercase character, 1 uppercase characters, 1 number, and 1 special character in (!@#$%^&*)")]
        public string Password { get; set; }
        public bool IsRemembered { get; set; }
    }
}
