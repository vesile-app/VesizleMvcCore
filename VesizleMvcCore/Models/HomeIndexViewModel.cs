using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VesizleMvcCore.NodejsApi.Entities;

namespace VesizleMvcCore.Models
{
    public class HomeIndexViewModel
    {
        public List<DiscoverCardModel> DiscoveryMovies { get; set; }
        public List<PopularCardModel> PopularMovies { get; set; }
    }
}
