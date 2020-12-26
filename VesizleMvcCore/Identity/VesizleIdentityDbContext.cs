using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace VesizleMvcCore.Identity
{
    public class VesizleIdentityDbContext : IdentityDbContext<VesizleUser>
    {
        public VesizleIdentityDbContext(DbContextOptions<VesizleIdentityDbContext> options) : base(options) { }
    }
}