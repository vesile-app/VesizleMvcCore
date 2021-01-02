using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VesizleMvcCore.Constants;
using VesizleMvcCore.Identity.Entities;

namespace VesizleMvcCore.Identity
{
    public class VesizleIdentityDbContext : IdentityDbContext<VesizleUser, VesizleRole,string>
    {
        public VesizleIdentityDbContext(DbContextOptions<VesizleIdentityDbContext> options) : base(options) { }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    Roles.Add(new VesizleRole { Name = UserRoleNames.Admin });
        //    Roles.Add(new VesizleRole { Name = UserRoleNames.Manager });
        //    Roles.Add(new VesizleRole { Name = UserRoleNames.Standard });
        //    SaveChanges();
        //}
    }
}