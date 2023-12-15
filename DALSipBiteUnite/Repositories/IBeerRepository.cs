// <copyright file="IBeerRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DALSipBiteUnite.Repositories
{
    using DALSipBiteUnite.DataBaseClasses;
    using DALSipBiteUnite.DbContext;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Interface for beer repository.
    /// </summary>
    public interface IBeerRepository
    {
        /// <summary>
        /// Adds a new beer.
        /// </summary>
        /// <param name="beer">The beer to add.</param>
        /// <returns>Returns true if the beer is successfully added.</returns>
        bool AddBeer(Beer beer);

        /// <summary>
        /// Updates a beer.
        /// </summary>
        /// <param name="beer">The beer to update.</param>
        /// <returns>Returns true if the beer is successfully updated.</returns>
        bool UpdateBeer(Beer beer);

        /// <summary>
        /// Deletes a beer.
        /// </summary>
        /// <param name="beerId">The ID of the beer to delete.</param>
        /// <returns>Returns true if the beer is successfully deleted.</returns>
        bool DeleteBeer(int beerId);

        /// <summary>
        /// Gets a beer by ID.
        /// </summary>
        /// <param name="beerId">The ID of the beer.</param>
        /// <returns>The requested beer.</returns>
        Beer GetBeerById(int beerId);

        /// <summary>
        /// Gets all beers.
        /// </summary>
        /// <returns>A list of all beers.</returns>
        List<Beer> GetAllBeers();
    }

    /// <summary>
    /// Repository for managing beers.
    /// </summary>
    public class BeerRepository : IBeerRepository
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="BeerRepository"/> class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        public BeerRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BeerRepository"/> class.
        /// </summary>
        public BeerRepository()
        {
        }

        /// <summary>
        /// Asynchronously gets the count of beers.
        /// </summary>
        /// <returns>The count of beers.</returns>
        public async Task<int> GetCountAsync()
        {
            return await this._context.Beers.CountAsync();
        }

        /// <summary>
        /// Adds a new beer to the database.
        /// </summary>
        /// <param name="beer">The beer object to be added.</param>
        /// <returns>True if the beer was successfully added, otherwise false.</returns>
        public bool AddBeer(Beer beer)
        {
            this._context.Beers.Add(beer);
            var saved = this._context.SaveChanges();
            return saved > 0;
        }

        /// <summary>
        /// Updates an existing beer in the database.
        /// </summary>
        /// <param name="beer">The beer object with updated information.</param>
        /// <returns>True if the beer was successfully updated, otherwise false.</returns>
        public bool UpdateBeer(Beer beer)
        {
            this._context.Beers.Update(beer);
            var saved = this._context.SaveChanges();
            return saved > 0;
        }

        /// <summary>
        /// Deletes a beer from the database by its ID.
        /// </summary>
        /// <param name="beerId">The ID of the beer to be deleted.</param>
        /// <returns>True if the beer was successfully deleted, otherwise false.</returns>
        public bool DeleteBeer(int beerId)
        {
            var beer = this._context.Beers.Find(beerId);
            if (beer != null)
            {
                this._context.Beers.Remove(beer);
                var saved = this._context.SaveChanges();
                return saved > 0;
            }

            return false;
        }

        /// <summary>
        /// Retrieves a beer from the database by its ID.
        /// </summary>
        /// <param name="beerId">The ID of the beer to retrieve.</param>
        /// <returns>The beer object if found, otherwise throws an InvalidOperationException.</returns>
        public Beer GetBeerById(int beerId)
        {
            return this._context.Beers.Find(beerId) ?? throw new InvalidOperationException("Beer not found.");
        }

        /// <summary>
        /// Retrieves all beers from the database.
        /// </summary>
        /// <returns>A list of all beers in the database.</returns>
        public List<Beer> GetAllBeers()
        {
            return this._context.Beers.ToList();
        }
    }
}
