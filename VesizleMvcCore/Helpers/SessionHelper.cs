using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using VesizleMvcCore.Extensions;
using VesizleMvcCore.NodejsApi.Entities;

namespace VesizleMvcCore.Helpers
{
    public class SessionHelper : ISessionHelper
    {
        private IHttpContextAccessor _accessor;
        private ISession _session;
        private string currentUserKey = "CurrentUser";
        private string userIdkey = "UserId";

        #region Session conf
        /*services.AddSession(options =>
        {
            // Set a short timeout for easy testing.
            options.IdleTimeout = TimeSpan.FromMinutes(10);
            options.Cookie.HttpOnly = true;
            // Make the session cookie essential
            options.Cookie.IsEssential = true;
        });*/
        #endregion
        public SessionHelper(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
            _session = accessor.HttpContext.Session;
        }

        public void Login(CurrentUser user)
        {
            HttpContext context = _accessor.HttpContext;
            if (context != null)
            {
                _session.Set(currentUserKey,user);
                _session.SetString(userIdkey, user.Id);
            }
        }

        public void Logout()
        {
            HttpContext context = _accessor.HttpContext;
            if (context != null)
            {
                _session.Remove(currentUserKey);
                _session.Remove(userIdkey);
            }
        }
        public CurrentUser GetCurrentUser()
        {
            return _session.Get<CurrentUser>(currentUserKey);
        }
        public string GetCurrentUserId()
        {
            HttpContext context = _accessor.HttpContext;
            if (context != null)
            {
                return _session.GetString(userIdkey);
            }
            return null;
        }
    }
}
