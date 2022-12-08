using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace _10DHTH.QuanLyTiemCamDo.DataAccess.ViewModels
{
	public class AdminRegisterRequest
	{
        public string TenNv { get; set; }
        public DateTime? NgaySinh { get; set; }
        [Required(ErrorMessage ="Phone Number is required!")]
        [Display(Name = "Sdt")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("/\\(?([0-9]{3})\\)?([ .-]?)([0-9]{3})\\2([0-9]{4})/", ErrorMessage = "Invalid Phone Number.")]
        public string Sdt { get; set; }
        public string Cmnd { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        [Display(Name = "Password")]
        [RegularExpression("^([a-zA-Z0-9@*#]{8,15})$", ErrorMessage = "Password must has at least 8 characters that include at least 1 lowercase character, 1 uppercase characters, 1 number, and 1 special character in (!@#$%^&*)")]
        public string Password { get; set; }
    }
}
