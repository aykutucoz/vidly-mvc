using System;
using System.Collections.Generic;
using System.Linq;
using Vidly.Models;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public int Id { get; set; }

        [Required(ErrorMessage = "İsim Alanı Girilmesi Zorunludur.")]
        [StringLength(255)]
        public string Name { get; set; }
       

        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }

        [Display(Name = "Release Date")]
        [Column(TypeName = "datetime2")]
        [Required]
        public DateTime? RealeseDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateAdded { get; set; }

        [Range(1,20)]
        [Display(Name = "Number In Stock")]
        [Required]
        public byte? NumberInStock { get; set; }

        public string Title            

        {
            get
            {
                if (Id!=0)
                {
                    return "Edit Movie";
                }
                return "New Movie";
            }
        }
        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie Movie)
        {
            Id = Movie.Id;
            Name = Movie.Name;
            RealeseDate = Movie.ReleaseDate;
            GenreId = Movie.GenreId;
            NumberInStock = Movie.NumberInStock;
        }
    }
}