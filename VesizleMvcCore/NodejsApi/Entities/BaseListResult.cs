using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VesizleMvcCore.NodejsApi.Entities
{
    public class BaseListResult<T> where T : class, new()
    {
        public int Page { get; set; }
        public List<T> Results { get; set; }
        public int Total_Pages { get; set; }
        public int Total_Results { get; set; }
    }
}
