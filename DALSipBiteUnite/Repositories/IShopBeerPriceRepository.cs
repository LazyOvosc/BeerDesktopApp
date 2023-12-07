// <copyright file="ShopBeerPriceRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DALSipBiteUnite.Repositories
{
    using DALSipBiteUnite.DataBaseClasses;

    /// <summary>
    /// Represents a repository for managing shop beer price-related operations.
    /// </summary>
    public interface IShopBeerPriceRepository
    {
        /// <summary>
        /// Adds a new shop beer price to the repository.
        /// </summary>
        /// <param name="shopBeerPrice">The shop beer price to add.</param>
        void AddShopBeerPrice(ShopBeerPrice shopBeerPrice);

        /// <summary>
        /// Updates an existing shop beer price in the repository.
        /// </summary>
        /// <param name="shopBeerPrice">The shop beer price to update.</param>
        void UpdateShopBeerPrice(ShopBeerPrice shopBeerPrice);

        /// <summary>
        /// Deletes a shop beer price from the repository based on its unique identifier.
        /// </summary>
        /// <param name="shopBeerPriceId">The unique identifier of the shop beer price to delete.</param>
        void DeleteShopBeerPrice(int shopBeerPriceId);

        /// <summary>
        /// Retrieves a shop beer price from the repository based on its unique identifier.
        /// </summary>
        /// <param name="shopBeerPriceId">The unique identifier of the shop beer price to retrieve.</param>
        /// <returns>The specified <see cref="ShopBeerPrice"/> or <c>null</c> if not found.</returns>
        ShopBeerPrice? GetShopBeerPriceById(int shopBeerPriceId);

        /// <summary>
        /// Retrieves a list of all shop beer prices from the repository.
        /// </summary>
        /// <returns>A <see cref="List{T}"/> of <see cref="ShopBeerPrice"/> objects representing all available shop beer prices.</returns>
        List<ShopBeerPrice> GetAllShopBeerPrices();
    }
}
