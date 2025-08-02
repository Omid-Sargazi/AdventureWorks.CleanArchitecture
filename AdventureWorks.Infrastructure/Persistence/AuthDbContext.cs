using AdventureWorks.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Infrastructure.Persistence
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }
        public DbSet<AppUser> Users => Set<AppUser>();
    }
}