using PurchaseSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PurchaseSystem.Controllers
{
    public class UserHomeController : Controller
    {
        ApplicationDbContext _db = new ApplicationDbContext();
        // GET: UserHome
        public ActionResult DisplayModule()
        {

            return View(_db.ModuleMsts.Where(a=>a.IsActive==1).ToList());
        }

    }
}