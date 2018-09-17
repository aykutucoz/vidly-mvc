using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="İsim Alanı Girilmesi Zorunludur.")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsleter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name="Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Min18Years]
        [Display(Name = "Date of Birth")]
        public DateTime? Birthdate { get; set; }
    }
}