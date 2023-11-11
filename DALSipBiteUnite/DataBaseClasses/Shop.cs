using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALSipBiteUnite.DataBaseClasses
{
    public class Shop
    {
        [Key]
        public int ShopId { get; set; }
        [Required]
        public string ShopName { get; set; }
    }
}
