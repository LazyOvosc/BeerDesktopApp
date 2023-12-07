// <copyright file="IFoodRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DALSipBiteUnite.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using DALSipBiteUnite.DataBaseClasses;
    using DALSipBiteUnite.DbContext;

    /// <summary>
    /// IFoodRepository interface.
    /// </summary>
    public interface IFoodRepository
    {
        /// <summary>
        /// Addes food.
        /// </summary>
        /// <param name="food">Food to add.</param>
        void AddFood(Food food);

        /// <summary>
        /// Updates food.
        /// </summary>
        /// <param name="food">Food to update.</param>
        void UpdateFood(Food food);

        /// <summary>
        /// Deletes food.
        /// </summary>
        /// <param name="foodId">Food to delete.</param>
        void DeleteFood(int foodId);

        /// <summary>
        /// Retrieves a food item by its unique identifier.
        /// </summary>
        /// <param name="foodId">The identifier of the food item to retrieve.</param>
        /// <returns>The <see cref="Food"/> object representing the specified food item.</returns>
        Food? GetFoodById(int foodId);

        /// <summary>
        /// Retrieves a list of all available food items.
        /// </summary>
        /// <returns>A list of <see cref="Food"/> objects representing all available food items.</returns>
        List<Food> GetAllFoods();
    }

    /// <summary>
    /// Repository for managing food-related operations.
    /// </summary>
    public class FoodRepository : IFoodRepository
    {
        private readonly ApplicationDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="FoodRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public FoodRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Adds a new food item to the database.
        /// </summary>
        /// <param name="food">The <see cref="Food"/> object representing the new food item.</param>
        public void AddFood(Food food)
        {
            _ = this.context.Foods.Add(food);
            _ = this.context.SaveChanges();
        }

        /// <summary>
        /// Updates an existing food item in the database.
        /// </summary>
        /// <param name="food">The <see cref="Food"/> object representing the updated food item.</param>
        public void UpdateFood(Food food)
        {
            _ = this.context.Foods.Update(food);
            _ = this.context.SaveChanges();
        }

        /// <summary>
        /// Deletes a food item from the database based on its unique identifier.
        /// </summary>
        /// <param name="foodId">The unique identifier of the food item to be deleted.</param>
        public void DeleteFood(int foodId)
        {
            var food = this.context.Foods.Find(foodId);
            if (food != null)
            {
                _ = this.context.Foods.Remove(food);
                _ = this.context.SaveChanges();
            }
        }

        /// <summary>
        /// Retrieves a food item from the database by its unique identifier.
        /// </summary>
        /// <param name="foodId">The ID of the food item to retrieve.</param>
        /// <returns>
        /// The specified <see cref="Food"/> or <c>null</c> if not found.
        /// </returns>
        /// <exception cref="NotFoundException">
        /// Thrown when the requested food item with the given ID is not found.
        /// </exception>
        public Food? GetFoodById(int foodId)
        {
            Food? result = this.context.Foods.Find(foodId);
            if (result == null)
            {
                // Handle the case where the food with the specified ID is not found.
                // You might throw an exception, return a default value, or take another action.
            }

            return result;
        }

        /// <summary>
        /// Retrieves a list of all food items from the database.
        /// </summary>
        /// <returns>
        /// A <see cref="List{T}"/> of <see cref="Food"/> objects representing all available food items.
        /// </returns>
        public List<Food> GetAllFoods()
        {
            return this.context.Foods.ToList();
        }
    }
}
