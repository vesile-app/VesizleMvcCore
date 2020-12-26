using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using VesizleMvcCore.Constants;

namespace VesizleMvcCore.Identity.CookieConfig
{
    public class CustomCookieAuthEvents : CookieAuthenticationEvents
    {
        public override Task RedirectToAccessDenied(RedirectContext<CookieAuthenticationOptions> context)
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            context.Response.WriteAsync(Messages.AccessDenied);
            return Task.CompletedTask;
        }

        public override Task RedirectToLogin(RedirectContext<CookieAuthenticationOptions> context)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.WriteAsync(Messages.Unauthorized);
            return Task.CompletedTask;
        }
        public override Task RedirectToLogout(RedirectContext<CookieAuthenticationOptions> context)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.WriteAsync(Messages.Unauthorized);
            return Task.CompletedTask;
        }
    }
}
