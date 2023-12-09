// <copyright file="Shop.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DALSipBiteUnite.DataBaseClasses
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Shop base class.
    /// </summary>
    public class Shop
    {
        /// <summary>
        /// Gets or sets ShopId.
        /// </summary>
        [Key]
        public int ShopId { get; set; }

        /// <summary>
        /// Gets or sets ShopName.
        /// </summary>
        [Required]
        public string? ShopName { get; set; }
    }
}
