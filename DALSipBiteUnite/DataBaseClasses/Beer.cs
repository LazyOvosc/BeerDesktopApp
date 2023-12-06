// <copyright file="Beer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DALSipBiteUnite.DataBaseClasses
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Beer base class.
    /// </summary>
    public class Beer
    {
        /// <summary>
        /// Gets or sets BeerId.
        /// </summary>
        [Key]
        public int BeerId { get; set; }

        /// <summary>
        /// Gets or sets BeerName.
        /// </summary>
        [Required]
        public string? BeerName { get; set; }

        /// <summary>
        /// Gets or sets BeerType.
        /// </summary>
        [Required]
        public string? BeerType { get; set; }

        /// <summary>
        /// Gets or sets BeerProducer.
        /// </summary>
        [Required]
        public string? BeerProducer { get; set; }

        /// <summary>
        /// Gets or sets BeerDescription.
        /// </summary>
        [Required]
        public string? BeerDescription { get; set; }

        /// <summary>
        /// Gets or sets BeerPhotoURL.
        /// </summary>
        public string? BeerPhotoURL { get; set; }
    }
}
