using AdventureWorks.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<ProductSubcategory> ProductSubcategories => Set<ProductSubcategory>();
        public DbSet<ProductCategory> ProductCategories => Set<ProductCategory>();
        public DbSet<SalesOrderDetail> SalesOrderDetails => Set<SalesOrderDetail>();
        public DbSet<SalesOrderHeader> SalesOrderHeaders => Set<SalesOrderHeader>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Person> Persons => Set<Person>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}