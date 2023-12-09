// <copyright file="ApplicationDbContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DALSipBiteUnite.DbContext
{
    using DALSipBiteUnite.DataBaseClasses;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// ApplicationDbContext base class.
    /// </summary>
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        public ApplicationDbContext()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options">set options here.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets Beers.
        /// </summary>
        public DbSet<Beer> Beers { get; set; }

        /// <summary>
        /// Gets or sets Foods.
        /// </summary>
        public DbSet<Food> Foods { get; set; }

        /// <summary>
        /// Gets or sets Ratings.
        /// </summary>
        public DbSet<Rating> Ratings { get; set; }

        /// <summary>
        /// Gets or sets Shops.
        /// </summary>
        public DbSet<Shop> Shops { get; set; }

        /// <summary>
        /// Gets or sets ShopBeerPrices.
        /// </summary>
        public DbSet<ShopBeerPrice> ShopBeerPrices { get; set; }

        /// <summary>
        /// Gets or sets Users.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=localhost;Port=5432;User Id=postgres;Password=Password123!;Database=DbSipBiteUnite;");
            }
        }
    }
}
