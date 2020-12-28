using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VesizleMvcCore.Models
{
    public class CastViewModel : BaseCreditViewModel
    {
        public string Character { get; set; }
        public int Order { get; set; }
    }
}
