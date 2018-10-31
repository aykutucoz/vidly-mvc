﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customers { get; set; }

        public int Id { get; set; }

        public string Title

        {
            get
            {
                if (Id != 0)
                {
                    return "Edit Customer";
                }
                return "New Customer";
            }
        }
        public CustomerFormViewModel()
        {
            Id = 0;
        }
    }
}