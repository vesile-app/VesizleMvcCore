using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using VesizleMvcCore.Identity.Entities;

namespace VesizleMvcCore.Identity
{
    public class VesizleUser : IdentityUser
    {
        public VesizleUser()
        {
            Favorites = new List<Favorite>();
            WatchLists = new List<WatchList>();
            WatchedLists = new List<WatchedList>();
        }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<WatchList> WatchLists { get; set; }
        public virtual ICollection<WatchedList> WatchedLists { get; set; }
    }
}
