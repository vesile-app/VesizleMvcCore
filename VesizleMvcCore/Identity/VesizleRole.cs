using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace VesizleMvcCore.Identity
{
    public class VesizleRole : IdentityRole<string>
    {
        public VesizleRole(string roleName) : base(roleName)
        {

        }

        public VesizleRole()
        {
        }
    }
}
