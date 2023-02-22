using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDB.Models
{
    public class Category
    {
        [Key]
        [Required] //add the required to the fields that need to be submitted to database every time
        public int CategoryID { get; set; }
        [Required]
        public string CategoryName { get; set; }
     



    }
}
