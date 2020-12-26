using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace VesizleMvcCore.Extensions
{
    public static class ModelStateExtensions
    {
        public static void AddIdentityError(this ModelStateDictionary dictionary, IEnumerable<IdentityError> errors)
        {
            foreach (var identityError in errors)
            {
                dictionary.AddModelError("", identityError.Description);
            }
        }
        public static void AddIdentityError(this ModelStateDictionary dictionary, string key,IEnumerable<IdentityError> errors)
        {
            foreach (var identityError in errors)
            {
                dictionary.AddModelError(key, identityError.Description);
            }
        }
    }
}
