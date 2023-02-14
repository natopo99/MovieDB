using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDB.Models
{
    public class MovieResponse
    {
        [Key]
        [Required] //add the required to the fields that need to be submitted to database every time
        public int MovieId { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required] //
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        //the ones that are not required are Edited, Lento, and Notes
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        [StringLength(25, ErrorMessage = "The field must be less than 25 characters")]
        public string Notes { get; set; }

    }
}
