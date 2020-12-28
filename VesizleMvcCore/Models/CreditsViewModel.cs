using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VesizleMvcCore.Models
{
    public class CreditsViewModel
    {
        public List<CastViewModel> CastViewModels { get; set; }
        public List<CrewViewModel> CrewViewModels { get; set; }
    }
}
