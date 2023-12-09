// <copyright file="Food.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DALSipBiteUnite.DataBaseClasses
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Food base class.
    /// </summary>
    public class Food
    {
        /// <summary>
        /// Gets or sets FoodId.
        /// </summary>
        [Key]
        public int FoodId { get; set; }

        /// <summary>
        /// Gets or sets FoodName.
        /// </summary>
        [Required]
        public string? FoodName { get; set; }

        /// <summary>
        /// Gets or sets FoodCategory.
        /// </summary>
        [Required]
        public string? FoodCategory { get; set; }

        /// <summary>
        /// Gets or sets FoodDescription.
        /// </summary>
        [Required]
        public string? FoodDescription { get; set; }

        /// <summary>
        /// Gets or sets FoodPhotoURL.
        /// </summary>
        public string? FoodPhotoURL { get; set; }
    }
}
