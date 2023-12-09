// <copyright file="ShopBeerPriceRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DALSipBiteUnite.Repositories
{
    using System.Collections.Generic;
    using DALSipBiteUnite.DataBaseClasses;
    using DALSipBiteUnite.DbContext;

    /// <summary>
    /// Repository for managing shop beer price-related operations.
    /// </summary>
    public class ShopBeerPriceRepository : IShopBeerPriceRepository
    {
        private readonly ApplicationDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShopBeerPriceRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public ShopBeerPriceRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Adds a new shop beer price to the repository.
        /// </summary>
        /// <param name="shopBeerPrice">The shop beer price to add.</param>
        public void AddShopBeerPrice(ShopBeerPrice shopBeerPrice)
        {
            this.context.ShopBeerPrices.Add(shopBeerPrice);
            this.context.SaveChanges();
        }

        /// <summary>
        /// Updates an existing shop beer price in the repository.
        /// </summary>
        /// <param name="shopBeerPrice">The shop beer price to update.</param>
        public void UpdateShopBeerPrice(ShopBeerPrice shopBeerPrice)
        {
            this.context.ShopBeerPrices.Update(shopBeerPrice);
            this.context.SaveChanges();
        }

        /// <summary>
        /// Deletes a shop beer price from the repository based on its unique identifier.
        /// </summary>
        /// <param name="shopBeerPriceId">The unique identifier of the shop beer price to delete.</param>
        public void DeleteShopBeerPrice(int shopBeerPriceId)
        {
            var shopBeerPrice = this.context.ShopBeerPrices.Find(shopBeerPriceId);
            if (shopBeerPrice != null)
            {
                this.context.ShopBeerPrices.Remove(shopBeerPrice);
                this.context.SaveChanges();
            }
        }

        /// <summary>
        /// Retrieves a shop beer price from the repository based on its unique identifier.
        /// </summary>
        /// <param name="shopBeerPriceId">The unique identifier of the shop beer price to retrieve.</param>
        /// <returns>The specified <see cref="ShopBeerPrice"/> or <c>null</c> if not found.</returns>
        public ShopBeerPrice? GetShopBeerPriceById(int shopBeerPriceId)
        {
            // Find the entity with the given primary key.
            var shopBeerPrice = this.context.ShopBeerPrices.Find(shopBeerPriceId);

            // Check if the entity is not found.
            if (shopBeerPrice == null)
            {
                // Handle the case where the entity is not found.
                // You might throw an exception, return a default value, or take another action.
            }

            // Return the found entity or null.
            return shopBeerPrice;
        }

        /// <summary>
        /// Retrieves a list of all shop beer prices from the repository.
        /// </summary>
        /// <returns>A <see cref="List{T}"/> of <see cref="ShopBeerPrice"/> objects representing all available shop beer prices.</returns>
        public List<ShopBeerPrice> GetAllShopBeerPrices()
        {
            return this.context.ShopBeerPrices.ToList();
        }
    }
}
