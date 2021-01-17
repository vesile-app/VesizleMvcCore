using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VesizleMvcCore.Models;

namespace VesizleMvcCore.DataAccess.RoleDal
{
    public interface IRoleDal
    {
        List<RoleDetailViewModel> GetRoles();
    }
}
