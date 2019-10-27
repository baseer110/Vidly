using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Genres
    {
        public byte Id { get; set; }
        [StringLength(255)]
        public String Name { get; set; }
    }
}