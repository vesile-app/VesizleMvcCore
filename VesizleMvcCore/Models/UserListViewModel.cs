using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VesizleMvcCore.Models
{
    public class UserListViewModel
    {
        public UserListViewModel()
        {
            Users = new List<UserDetailForAdminModel>();
        }
        public List<UserDetailForAdminModel> Users { get; set; }
        public AddUserRoleModel AddUserRoleModel { get; set; }
        public RemoveUserRoleModel RemoveUserRoleModel { get; set; }
    }
}
