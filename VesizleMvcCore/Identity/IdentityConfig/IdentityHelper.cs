using System;

namespace VesizleMvcCore.Identity.IdentityConfig
{
    public class IdentityHelper
    {
        public static string UserNameGenerate(string firstName = "user")
        {
            return (firstName + "." + Guid.NewGuid().ToString("N")).ToLower();
        }
    }
}
