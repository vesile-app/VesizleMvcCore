using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VesizleMvcCore.Models
{
    public class FavoriteListViewModel
    {
        public FavoriteListViewModel()
        {
            FavoriteDetailViewModels=new List<FavoriteDetailViewModel>();
        }
        public List<FavoriteDetailViewModel> FavoriteDetailViewModels { get; set; }
        public int Count { get; set; }
    }
}
