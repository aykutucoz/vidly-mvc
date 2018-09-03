using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class RandomMovieViewModel
    {
        public Models.Movie Movie { get; set; }
        public List<Models.Customer> Customers { get; set; }
    }
}