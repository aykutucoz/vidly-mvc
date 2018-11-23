using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class UpdateRentalsViewModel
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public DateTime RentedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public int CustomerID { get; set; }
        public int MovieID { get; set; }

    }
    
}