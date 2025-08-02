using AdventureWorks.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Infrastructure.Persistence
{
    public class AuthinticationDbContext : DbContext
    {
        public AuthinticationDbContext(DbContextOptions<AuthinticationDbContext> options) : base(options) { }
        public DbSet<AppUser> Users => Set<AppUser>();


       
    }
}