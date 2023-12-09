// <copyright file="IRatingRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DALSipBiteUnite.Repositories
{
    using DALSipBiteUnite.DataBaseClasses;

    /// <summary>
    /// Repository for managing rating-related operations.
    /// </summary>
    public interface IRatingRepository
    {
        /// <summary>
        /// Adds a new rating to the repository.
        /// </summary>
        /// <param name="rating">The rating to add.</param>
        void AddRating(Rating rating);

        /// <summary>
        /// Updates an existing rating in the repository.
        /// </summary>
        /// <param name="rating">The rating to update.</param>
        void UpdateRating(Rating rating);

        /// <summary>
        /// Deletes a rating from the repository based on its unique identifier.
        /// </summary>
        /// <param name="ratingId">The unique identifier of the rating to delete.</param>
        void DeleteRating(int ratingId);

        /// <summary>
        /// Retrieves a rating from the repository based on its unique identifier.
        /// </summary>
        /// <param name="ratingId">The unique identifier of the rating to retrieve.</param>
        /// <returns>The specified <see cref="Rating"/> or <c>null</c> if not found.</returns>
        Rating? GetRatingById(int ratingId);

        /// <summary>
        /// Retrieves a list of all ratings from the repository.
        /// </summary>
        /// <returns>A <see cref="List{T}"/> of <see cref="Rating"/> objects representing all available ratings.</returns>
        List<Rating> GetAllRatings();
    }
}
