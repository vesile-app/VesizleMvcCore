using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VesizleMvcCore.NodejsApi.Entities
{
    public class Credits
    {
        public List<Cast> Cast { get; set; }
        public List<Crew> Crew { get; set; }
    }
}
