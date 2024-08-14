using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Customer_Deatails.Controllers
{
    public class CustomerController : Controller
    {
        North_windEntities db = new North_windEntities();
        // GET: Customer
        public ActionResult German_Customer()
        {
            var german_customer = db.Customers.Where(c => c.Country == "Germany").ToList();


            return View(german_customer);
        }

        public ActionResult Customer_Details(int orderId = 10248)
        {
            var order = db.Orders
                        .Where(o => o.OrderID == orderId)
                        .Select(o => o.Customer)
                        .FirstOrDefault();
            return View(order);
        }

   
    }

    }
