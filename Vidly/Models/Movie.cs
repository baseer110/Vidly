﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime AddedDate { get; set; }

        [Required]
        [Display(Name="Number in Stock")]
        public int NumberInStock { get; set; }

        public Genres Genre { get; set; }

        [Display(Name="Genre")]
        [Required]
        public byte GenreId { get; set; }

        [Display(Name="Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }
    }
}