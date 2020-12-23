using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VesizleMvcCore.Constants;

namespace VesizleMvcCore.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "email alanı gereklidir.")]
        [EmailAddress(ErrorMessage = "doğru bir e-mail adresi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "şifre alanı gereklidir.")]
        public string Password { get; set; }
    }
}
