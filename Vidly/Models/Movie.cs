﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public DateTime RealeseDate { get; set; }
        public DateTime DateAdded { get; set; }
        public int NumberInStock { get; set; }

    }
}