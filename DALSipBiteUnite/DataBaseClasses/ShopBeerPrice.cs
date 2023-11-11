using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALSipBiteUnite.DataBaseClasses
{
    public class ShopBeerPrice
    {
        [Key]
        public int ShopBeerPriceId { get; set; }
        [Required]
        public int ShopId { get; set; }
        [Required]
        public int BeerId { get; set; }
        [Range(0.00, double.MaxValue, ErrorMessage = "ShopBeerPrice must be greater than 0.")]
        [Required]
        public decimal Price { get; set; }
        public string ShopBeerPriceURL { get; set; }
    }
}
