using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Web;

namespace VesizleMvcCore.Helpers
{
    public class JsonHelper
    {
        public static T Deserialize<T>(string jsonText)
        {
            T result = JsonSerializer.Deserialize<T>(jsonText, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
            return result;
        }
        public static string Serialize(object obj)
        {
            string jsonText = JsonSerializer.Serialize(obj);
            return jsonText;
        }
        public static string Serialize<T>(T obj)
        {
            string jsonText = JsonSerializer.Serialize<T>(obj, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
            return jsonText;
        }
    }
}