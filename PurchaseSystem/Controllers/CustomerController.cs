using PurchaseSystem.Common;
using PurchaseSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PurchaseSystem.Controllers
{
    public class CustomerController : Controller
    {
        ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Customer
        public ActionResult CustomerList()
        {
            IEnumerable<CustomerMst> customerList;
            if(User.IsInRole("Admin"))
            {
                customerList = _db.CustomerMsts.ToList();
            }
            else
            {
                customerList = _db.CustomerMsts.Where(a => a.Username == User.Identity.Name);
            }
            
            return View(customerList);
        }

        public ActionResult SaveUpdateCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveUpdateCustomer(CustomerMst customerMst)
        {
            customerMst.Username = User.Identity.Name;
            _db.CustomerMsts.Add(customerMst);
            _db.SaveChanges();

            return RedirectToAction("CustomerList");
        }
    }
}