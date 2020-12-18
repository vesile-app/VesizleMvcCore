using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vesizle.NodejsApi.Entities;

namespace VesizleMvcCore.NodejsApi.ApiResults
{
    public class ApiSearchResult
    {
        public int Page { get; set; }
        public List<Movie> Results { get; set; }
        public int Total_Pages { get; set; }
        public int Total_Results { get; set; }
    }
}