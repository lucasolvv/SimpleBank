using Microsoft.EntityFrameworkCore;
using SimpleBank.Domain;
using SimpleBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank.Infra.Context
{
    public class DbConfig : DbContext
    {
        public DbConfig(DbContextOptions <DbConfig> options) : base(options) { } 

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
