// <copyright file="ShopBeerPrice.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DALSipBiteUnite.DataBaseClasses
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// ShopBeerPrice base class.
    /// </summary>
    public class ShopBeerPrice
    {
        /// <summary>
        /// Gets or sets ShopBeerPriceId.
        /// </summary>
        [Key]
        public int ShopBeerPriceId { get; set; }

        /// <summary>
        /// Gets or sets ShopId.
        /// </summary>
        [Required]
        public int ShopId { get; set; }

        /// <summary>
        /// Gets or sets BeerId.
        /// </summary>
        [Required]
        public int BeerId { get; set; }

        /// <summary>
        /// Gets or sets Price.
        /// </summary>
        [Range(0.00, double.MaxValue, ErrorMessage = "ShopBeerPrice must be greater than 0.")]
        [Required]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets ShopBeerPriceURL.
        /// </summary>
        public string? ShopBeerPriceURL { get; set; }
    }
}
