using Microsoft.EntityFrameworkCore;
using MVC221202021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC221202021
{
    public class Context : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Email> Emails { get; set; }
        public Context()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost; initial Catalog=AulaEntity; User ID=usuario; password=senha; language= Portuguese;Trusted_Connection=True");
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Email>()
                .HasOne(e => e.pessoa)
                .WithMany(p => p.Emails)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
