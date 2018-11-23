using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.ViewModels
{
    public class PeopleSelectionViewModel
    {
        public List<SelectPersonViewModel> People { get; set; }

        public PeopleSelectionViewModel()
        {
            this.People = new List<SelectPersonViewModel>();
        }

        public IEnumerable<int> getSelectedIds()
        {
            return (from p in this.People where p.Selected select p.Id).ToList();
        }
    }
}