using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VesizleMvcCore.Models
{
    public class WatchedListViewModel
    {
        public WatchedListViewModel()
        {
            WatchedListDetailViewModels = new List<WatchedListDetailViewModel>();
        }
        public List<WatchedListDetailViewModel> WatchedListDetailViewModels { get; set; }
        public int Count { get; set; }
    }
}
