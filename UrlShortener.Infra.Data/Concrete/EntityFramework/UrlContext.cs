using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Domain.Entities;
using UrlShortener.Infra.Data.Concrete.Mappings;

namespace UrlShortener.Infra.Data.Concrete.EntityFramework
{
    public class UrlContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=UrlShortenerCQRS;Trusted_Connection=true");

        }

        public DbSet<UrlModal> UrlModals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UrlModalMapper());

        }

    }
}
