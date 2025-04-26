using Microsoft.EntityFrameworkCore;
using SimpleBank.Domain.Entities;

namespace SimpleBank.Infra.Context
{
    public class SimpleBankDbContext : DbContext
    {
        public SimpleBankDbContext(DbContextOptions <SimpleBankDbContext> options) : base(options) { } 

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SimpleBankDbContext).Assembly);
        }
    }
}
