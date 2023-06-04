using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class BaseDbContext:DbContext
    {
        protected IConfiguration Configuration { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration=configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(b => 
            {
                b.ToTable("Brands").HasKey(k=>k.Id);
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.Name).HasColumnName("Name");
            });

            Brand[] brandSeedData = { new(1, "AUDI"), new(2, "BMW"), new(3, "YAMAHA"), new(4, "HONDA") };
            modelBuilder.Entity<Brand>().HasData(brandSeedData);
        }
    }
}
