using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBookStore.Models.UtilsModel
{
    public class RegisterModel
    {
        [Key]
        public long ID { set; get; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Yêu cầu nhập email")]
        public string Email { set; get; }

        [Display(Name = "Mật khẩu")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Độ dài mật khẩu ít nhất 3 ký tự.")]
        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu")]
        public string MatKhau { set; get; }

        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("MatKhau", ErrorMessage = "Xác nhận mật khẩu không đúng.")]
        public string XacNhanMatKhau { set; get; }

        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Yêu cầu nhập họ tên")]
        public string HoVaTen { set; get; }

        [Display(Name = "Số điện thoại")]
        public string SDT { set; get; }

        [Display(Name = "Địa chỉ")]
        public string DiaChi { set; get; }
    }
}