using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VesizleMvcCore.Models
{
    public class BaseProfileLists
    {
        public decimal VoteAverage { get; set; }
        public int MovieId { get; set; }
        public string PosterUrl { get; set; }
        public string Title { get; set; }
    }
}
