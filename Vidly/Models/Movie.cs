using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Vidly.Models;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }
        
        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public int GenreId { get; set; }

        [Display(Name = "Release Date")]
        [Column(TypeName = "datetime2")]
        public DateTime RealeseDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Number In Stock")]
        public int NumberInStock { get; set; }

    }
}