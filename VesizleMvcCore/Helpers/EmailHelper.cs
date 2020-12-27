using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web;
using VesizleMvcCore.Constants;
using VesizleMvcCore.NodejsApi.ApiResults.Results;

namespace VesizleMvcCore.Helpers
{
    public class EmailHelper
    {
        public IResult SendEmailResetPassword(string userEmail, string userId, string resetToken)
        {
            IResult result;
            MailMessage mail = new MailMessage();
            mail.IsBodyHtml = true;
            mail.To.Add(userEmail);
            mail.From = new MailAddress(AppConstants.VesizleEmail, "Reset password", System.Text.Encoding.UTF8);
            mail.Subject = "Password reset request";
            string url = $"UpdatePassword/{userId}/{HttpUtility.UrlEncode(resetToken)}";
            mail.Body = $"<a target=\"_blank\" href=\"https://localhost:44363/{url}\">Click </a>to request a new password.";
            mail.IsBodyHtml = true;
            SmtpClient smp = new SmtpClient
            {
                Credentials = new NetworkCredential(AppConstants.VesizleEmail, AppConstants.VesizlePassword),
                Port = 587,
                Host = "smtp.gmail.com",
                EnableSsl = true,
                UseDefaultCredentials = true
            };
            try
            {
                smp.Send(mail);
                result = new SuccessResult();
            }
            catch (Exception e)
            {
                result = new ErrorResult();
            }

            return result;
        }
    }
}
