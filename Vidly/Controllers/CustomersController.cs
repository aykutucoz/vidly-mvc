﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c=>c.MembershipType).ToList();
            return View(customers);
        }
        
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm",viewModel);
        }
        [HttpPost]
        public ActionResult Save(CustomerFormViewModel customer)
        {
            if (customer.Customers.Id == 0)
            {
                _context.Customers.Add(customer.Customers);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Customers.Id);

                //TryUpdateModel(customerInDb); güvenli olmayan bir yöntem.AutoMapper kullanılabilir.
                // Mapper.Map(customer,customerInDb);
                customerInDb.Name = customer.Customers.Name;
                customerInDb.Birthdate = customer.Customers.Birthdate;
                customerInDb.MembershipTypeId = customer.Customers.MembershipTypeId;
                customerInDb.IsSubscribedToNewsleter = customer.Customers.IsSubscribedToNewsleter;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
            

            return RedirectToAction("Index","Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CustomerFormViewModel
            {
                Customers = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }

    }
}