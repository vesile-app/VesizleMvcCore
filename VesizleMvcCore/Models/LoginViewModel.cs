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
        [Required(ErrorMessage = "Email boş geçilemez.")]
        [EmailAddress(ErrorMessage = "Doğru bir e-mail adresi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password boş geçilemez.")]
        public string Password { get; set; }
    }
}
