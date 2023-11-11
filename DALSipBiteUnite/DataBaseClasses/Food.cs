using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALSipBiteUnite.DataBaseClasses
{
    public class Food
    {
        [Key]
        public int FoodId { get; set; }
        [Required]
        public string FoodName { get; set; }
        [Required]
        public string FoodCategory { get; set; }
        [Required]
        public string FoodDescription { get; set; }
        public string FoodPhotoURL { get; set; }
    }
}
