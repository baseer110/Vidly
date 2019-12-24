using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public DateTime AddedDate { get; set; }

        [Required]
        [Display(Name = "Number in Stock")]
        public int NumberInStock { get; set; }
        
        [Required]
        public byte GenreId { get; set; }
        
        [Required]
        public DateTime? ReleaseDate { get; set; }
    }
}