using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AdventureWorks.Infrastructure.Persistence
{
    public class AuthinticationDbContextFactory : IDesignTimeDbContextFactory<AuthinticationDbContext>
    {
        public AuthinticationDbContext CreateDbContext(string[] args)
        {
           var optionsBuilder = new DbContextOptionsBuilder<AuthinticationDbContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=AdventureWorksAuthDb;User Id=sa;Password=15935755Omid$@;Encrypt=False;");

            return new AuthinticationDbContext(optionsBuilder.Options);

     
        }
    }
}