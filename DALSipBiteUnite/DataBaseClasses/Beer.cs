using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALSipBiteUnite.DataBaseClasses
{
    public class Beer
    {
        [Key]
        public int BeerId { get; set; }
        [Required]
        public string BeerName { get; set; }
        [Required]
        public string BeerType { get; set; }
        [Required]
        public string BeerProducer { get; set; }
        [Required]
        public string BeerDescription { get; set; }
        public string BeerPhotoURL { get; set; }
    }
}
