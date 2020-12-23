using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vesizle.NodejsApi.Entities;
using VesizleMvcCore.NodejsApi.Entities;

namespace VesizleMvcCore.NodejsApi.ApiResults
{
    public class ApiPopularResult
    {
        public int Page { get; set; }
        public List<PopularMovie> Results { get; set; }
        public int Total_Pages { get; set; }
        public int Total_Results { get; set; }
    }
}