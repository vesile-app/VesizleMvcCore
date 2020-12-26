using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VesizleMvcCore.Constants
{
    public static class Messages
    {
        public static string Required = "Bu alan zorunludur.";
        public static string Email = "Doğru bir e-mail adresi giriniz.";

        //App
        public static string LoginFailed = "Email veya password hatalı.";
        public static string RegisterSuccess = "Register Success: Register was success.";
        public static string RoleCreateSuccess = "Role create was success.";
        public static string RoleNotFound = "Role not found";
        public static string RoleOrUserNotFound = "Role or user not found";
        public static string RoleDeleteSuccess = "Role deleted to successful.";
        public static string AddToRoleSuccess = "Role Added to successful..";
        public static string RemoveToRoleSuccess = "Role removed to successful.";
        public static string OldPasswordFail = "Eski şifre hatalı.";
        public static string LoginSuccess = "Giriş başarılı.";

        //Auth
        public static string AccessDenied = "Access denied.";
        public static string Unauthorized = "Unauthorized.";
    }
}
