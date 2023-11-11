using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALSipBiteUnite.DataBaseClasses;
using Microsoft.EntityFrameworkCore;

namespace DALSipBiteUnite.DbContext
{
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Beer> Beers { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<ShopBeerPrice> ShopBeerPrices { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(): base()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=localhost;Port=5432;User Id=postgres;Password=BlueDragonOld!_21;Database=DbSipBiteUnite;");
            }
        }

    }
}
