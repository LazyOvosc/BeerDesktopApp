// <copyright file="RatingRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DALSipBiteUnite.Repositories
{
    using DALSipBiteUnite.DataBaseClasses;
    using DALSipBiteUnite.DbContext;

    /// <summary>
    /// Repository for managing rating-related operations.
    /// </summary>
    public class RatingRepository : IRatingRepository
    {
        private readonly ApplicationDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="RatingRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public RatingRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Adds a new rating to the database.
        /// </summary>
        /// <param name="rating">rating id.</param>
        public void AddRating(Rating rating)
        {
            this.context.Ratings.Add(rating);
            this.context.SaveChanges();
        }

        /// <summary>
        /// Updates an existing rating in the database.
        /// </summary>
        /// <param name="rating">rating id.</param>
        public void UpdateRating(Rating rating)
        {
            this.context.Ratings.Update(rating);
            this.context.SaveChanges();
        }

        /// <summary>
        /// Deletes a rating from the database based on its unique identifier.
        /// </summary>
        /// <param name="ratingId">rating id.</param>
        public void DeleteRating(int ratingId)
        {
            var rating = this.context.Ratings.Find(ratingId);
            if (rating != null)
            {
                this.context.Ratings.Remove(rating);
                this.context.SaveChanges();
            }
        }

        /// <summary>
        /// Retrieves a rating from the database based on its unique identifier.
        /// </summary>
        /// <param name="ratingId">rating id.</param>
        /// <returns>The specified <see cref="Rating"/> or <c>null</c> if not found.</returns>
        public Rating? GetRatingById(int ratingId)
        {
            return this.context.Ratings.Find(ratingId);
        }

        /// <summary>
        /// Retrieves a list of all ratings from the database.
        /// </summary>
        /// <returns>A <see cref="List{T}"/> of <see cref="Rating"/> objects representing all available ratings.</returns>
        public List<Rating> GetAllRatings()
        {
            return this.context.Ratings.ToList();
        }
    }
}
