using PurchaseSystem.Common;
using PurchaseSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PurchaseSystem.Controllers
{
    public class ModuleController : Controller
    {
        ApplicationDbContext _db = new ApplicationDbContext();

        public ActionResult ModuleList()
        {

            return View(_db.ModuleMsts.ToList());
        }

        [HttpGet]
        public ActionResult CreateModule()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateModule(ModuleMst module)
        {
            _db.ModuleMsts.Add(module);
            _db.SaveChanges();

            return View();
        }

    }
}