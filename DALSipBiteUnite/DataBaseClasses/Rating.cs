// <copyright file="Rating.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DALSipBiteUnite.DataBaseClasses
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Rating base class.
    /// </summary>
    public class Rating
    {
        /// <summary>
        /// Gets or sets RatingId.
        /// </summary>
        [Key]
        public int RatingId { get; set; }

        /// <summary>
        /// Gets or sets BeerId.
        /// </summary>
        [Required]
        public int BeerId { get; set; }

        /// <summary>
        /// Gets or sets FoodId.
        /// </summary>
        [Required]
        public int FoodId { get; set; }

        /// <summary>
        /// Gets or sets RatingValue between 0 and 10.
        /// </summary>
        [Range(0.0, 10.0, ErrorMessage = "Rating must be between 0 and 10.")]
        [Required]
        public float RatingValue { get; set; }

        /// <summary>
        /// Gets or sets userId.
        /// </summary>
        [Required]
        public int UserId { get; set; }
    }
}
