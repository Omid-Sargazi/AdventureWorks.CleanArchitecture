using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AdventureWorks.Infrastructure.Persistence
{
    public class AuthDbContextFactory : IDesignTimeDbContextFactory<AuthDbContext>
    {
        public AuthDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AuthDbContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=AdventureWorksAuthDb;User Id=sa;Password=15935755Omid$@;Encrypt=False;");
            return new AuthDbContext(optionsBuilder.Options);
        }
    }
}