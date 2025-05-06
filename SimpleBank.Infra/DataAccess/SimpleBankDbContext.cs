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
            modelBuilder.Entity<User>()
                .Property(u => u.AccountType)
                .HasConversion(
                    value => value.ToString(), // Converte enum para string ao salvar
                    value => (AccountType)Enum.Parse(typeof(AccountType), value) // Converte string para enum ao carregar
                );

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SimpleBankDbContext).Assembly);
            
        }
    }
}
