﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "İsim Alanı Girilmesi Zorunludur.")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsleter { get; set; }

        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        //[Min18Years]
        public DateTime? Birthdate { get; set; }
    }
}