using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var customers = GetCutomers();
            return View(customers);
        }

        public ActionResult Details(int id) 
        {
            var customer = GetCutomers().SingleOrDefault(c => c.Id == id);
            return View(customer);
        }

        private IEnumerable<Customer> GetCutomers()
        {
            return new List<Customer>
            {
                new Customer{Id = 1, Name = "John Smith"},
                new Customer{Id = 2, Name = "Mary Williams"}
            };
        }
    }
}