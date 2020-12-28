using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.WebUtilities;
using VesizleMvcCore.Constants;
using VesizleMvcCore.NodejsApi.ApiResults.Results;

namespace VesizleMvcCore.Helpers
{
    public class EmailHelper
    {
        public IResult SendEmailResetPassword(string userEmail, string userId, string resetToken)
        {
            IResult result;
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.IsBodyHtml = true;
                    mail.To.Add(userEmail);
                    mail.From = new MailAddress(AppConstants.VesizleEmail, "Reset password", System.Text.Encoding.UTF8);
                    mail.Subject = "Password reset request";
                    byte[] tokenGeneratedBytes = Encoding.UTF8.GetBytes(resetToken);
                    var codeEncoded = WebEncoders.Base64UrlEncode(tokenGeneratedBytes);
                    string url = $"UpdatePassword/{userId}/{codeEncoded}";
                    //Todo: sizde hangi portta çalışıyorsa o porttu yazın
                    mail.Body = $"<a target=\"_blank\" href=\"https://localhost:5001/{url}\">Click </a>to request a new password.";
                    mail.IsBodyHtml = true;
                    using (SmtpClient smp = new SmtpClient())
                    {
                        smp.Port = 587;
                        smp.Host = "smtp.gmail.com";
                        smp.EnableSsl = true;
                        smp.UseDefaultCredentials = true;
                        smp.Credentials = new NetworkCredential(AppConstants.VesizleEmail, AppConstants.VesizlePassword);
                        smp.Send(mail);
                    }
                }
               
                result = new SuccessResult();
            }
            catch (Exception e)
            {
                result = new ErrorResult(e.Message);
            }

            return result;
        }
    }
}
