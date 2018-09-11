using System;
using System.Collections.Generic;
using System.Linq;
using Vidly.Models;
using System.Web;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movies { get; set; }

        public string Title
        {
            get
            {
                if (Movies != null && Movies.Id!=0)
                {
                    return "Edit Movie";
                }
                return "New Movie";
            }
        }
    }
}