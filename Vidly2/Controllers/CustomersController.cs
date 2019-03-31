using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;

namespace Vidly2.Controllers
{
    public class CustomersController : Controller
    {
        List<Customer> customersList = new List<Customer>()
            {
                new Customer{Name = "Rafał Jawoszek"},
                new Customer{Name = "Jan Kowalski"}
            };

        [Route("Customers")]
        public ActionResult Index()
        {
            return View(customersList);
        }

        [Route("Customers/Details/{Id}")]
        public ActionResult Details(int Id)
        {
            return View(customersList[Id]);
        }
    }
}