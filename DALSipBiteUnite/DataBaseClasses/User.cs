// <copyright file="User.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DALSipBiteUnite.DataBaseClasses
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// User base class.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets UserId.
        /// </summary>
        [Key]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets UserPassword.
        /// </summary>
        [Required]
        public string? UserPassword { get; set; }

        /// <summary>
        /// Gets or sets UserEmail.
        /// </summary>
        [Required]
        [EmailAddress]
        public string? UserEmail { get; set; }
    }
}
