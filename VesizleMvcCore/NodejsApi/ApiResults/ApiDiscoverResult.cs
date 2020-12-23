using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vesizle.NodejsApi.Entities;
using VesizleMvcCore.NodejsApi.Entities;

namespace VesizleMvcCore.NodejsApi.ApiResults
{
    public class ApiDiscoverResult
    {
        public int Page { get; set; }
        public List<DiscoveryMovie> Results { get; set; }
        public int Total_Pages { get; set; }
        public int Total_Results { get; set; }
    }
}
