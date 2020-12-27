using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vesizle.NodejsApi.Entities;

namespace VesizleMvcCore.Models
{
    public class SearchViewModel
    {
        public int Page { get; set; }
        public List<SearchDetailViewModel> Results { get; set; }
        public int TotalPages { get; set; }
        public int TotalResults { get; set; }
    }
}
