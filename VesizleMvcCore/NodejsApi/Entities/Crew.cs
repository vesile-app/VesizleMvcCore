using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VesizleMvcCore.NodejsApi.Entities
{
    public class Crew : BaseCredits
    {
        public string Department { get; set; }
        public string Job { get; set; }
    }
}
