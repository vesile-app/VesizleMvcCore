using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VesizleMvcCore.NodejsApi.Entities;

namespace VesizleMvcCore.Models
{
    public class MovieDetailsViewModel
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string PosterUrl{ get; set; }
        public string Overview { get; set; }
        public string YoutubeUrl { get; set; }

        public CreditsViewModel CreditsViewModel { get; set; }

        public RecommendationsModel Recommendations { get; set; }
    }
}
