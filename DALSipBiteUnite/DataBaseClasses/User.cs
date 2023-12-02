using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALSipBiteUnite.DataBaseClasses
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string UserPassword { get; set; }
        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }
    }

}
