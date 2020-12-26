using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace VesizleMvcCore.Identity.IdentityConfig
{
    public static class PasswordValidatorExtension
    {
        public static async Task<IdentityResult> CustomValidateAsync(this IPasswordValidator<VesizleUser> validator,
            UserManager<VesizleUser> userManager, VesizleUser user, string password)
        {
            var identityResult = await validator.ValidateAsync(userManager, user, password);
            List<IdentityError> errors = identityResult.Succeeded ? new List<IdentityError>() : identityResult.Errors.ToList();

            if (password.ToLower().Contains(user.UserName.ToLower()))
            {
                errors.Add(new IdentityError
                {
                    Description = "Password cannot contain username"
                });
            }
            if (password.Contains("123"))
            {
                errors.Add(new IdentityError
                {
                    Description = "Password cannot contain 123 numeric sequence"
                });
            }
            return errors.Count == 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray());
        }
    }
}

