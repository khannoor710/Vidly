using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            NewCustomerViewModel newCustomerViewModel = new NewCustomerViewModel()
            {
                MembershipTypes = membershipTypes
            };
            return View(newCustomerViewModel);
        }

        // GET: Customer
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Details(int id) 
        {
            var customer = _context.Customers.Include(c =>c.MembershipType).SingleOrDefault(c => c.Id == id);
            return View(customer);
        }
    }
}