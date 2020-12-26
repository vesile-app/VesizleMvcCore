using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using VesizleMvcCore.Helpers;

namespace VesizleMvcCore.Extensions
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonHelper.Serialize(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) :
                JsonHelper.Deserialize<T>(value);
        }
        public static string GetCurrentUserId(this ISession session)
        {
            var value = session.GetString("UserId");

            return value;
        }
    }
}
