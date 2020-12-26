using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VesizleMvcCore.NodejsApi.Entities;

namespace VesizleMvcCore.Helpers
{
    interface ISessionHelper
    {

        void Login(CurrentUser user);
        void Logout();
        CurrentUser GetCurrentUser();
        string GetCurrentUserId();
    }
}
