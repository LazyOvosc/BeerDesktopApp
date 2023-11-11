using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALSipBiteUnite.DataBaseClasses
{
    public class Rating
    {
        [Key]
        public int RatingId { get; set; }
        [Required]
        public int BeerId { get; set; }
        [Required]
        public int FoodId { get; set; }
        [Range(0.0, 10.0, ErrorMessage = "Rating must be between 0 and 10.")]
        [Required]
        public float RatingValue { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
