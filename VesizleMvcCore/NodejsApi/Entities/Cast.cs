using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VesizleMvcCore.NodejsApi.Entities
{
    public class Cast : BaseCredits
    {
        public int Cast_Id { get; set; }
        public string Character { get; set; }
        public int Order { get; set; }
    }
}
