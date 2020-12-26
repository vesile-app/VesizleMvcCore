using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VesizleMvcCore.Identity.IdentityConfig;

namespace VesizleMvcCore.Models
{
    public class RegisterViewModel
    {

        private string _firstName;

        
        [Required]
        public string FirstName
        {
            get => _firstName;
            set
            {
                this.UserName = IdentityHelper.UserNameGenerate(value);
                _firstName = value;
            }
        }
        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6,ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password")]
        public string RePassword { get; set; }
        [JsonIgnore]
        public string UserName { get; set; }
    }
}
