using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VesizleMvcCore.Models
{
    public class WatchListViewModel
    {
        public WatchListViewModel()
        {
            WatchListDetailViewModels = new List<WatchListDetailViewModel>();
        }
        public List<WatchListDetailViewModel> WatchListDetailViewModels { get; set; }
    }
}
