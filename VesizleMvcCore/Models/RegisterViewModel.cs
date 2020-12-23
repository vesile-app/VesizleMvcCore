using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VesizleMvcCore.Models
{
    public class RegisterViewModel
    {

        [Required(ErrorMessage = "isim alanı gereklidir.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "soyisim alanı gereklidir.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "email alanı gereklidir.")]
        [EmailAddress(ErrorMessage = "doğru bir e-mail adresi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "şifre alanı gereklidir.")]
        [StringLength(int.MaxValue, MinimumLength = 6, ErrorMessage = "şifre en az 6 karekterli olmalıdır.")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "şifreler Eşleşmiyor.")]
        public string RePassword { get; set; }
    }
}
