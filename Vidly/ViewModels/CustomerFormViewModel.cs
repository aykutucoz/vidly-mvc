using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        [Required(ErrorMessage = "İsim Alanı Girilmesi Zorunludur.")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsleter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Min18Years]
        [Display(Name = "Date of Birth")]
        public DateTime? Birthdate { get; set; }

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

        public CustomerFormViewModel(Customer customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            MembershipTypeId = customer.MembershipTypeId;
            Birthdate = customer.Birthdate;
            IsSubscribedToNewsleter = customer.IsSubscribedToNewsleter;
        }
    }
}