using PurchaseSystem.Common;
using PurchaseSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PurchaseSystem.Controllers
{
    [Authorize]
    public class UserHomeController : Controller
    {
        ApplicationDbContext _db = new ApplicationDbContext();
        // GET: UserHome
        public ActionResult DisplayModule()
        {
            List<ModuleMst> ModuleList;
            if(User.IsInRole("Admin"))
            {
                ModuleList = _db.ModuleMsts.Where(a => a.IsActive == 1).ToList();
            }
            else if(User.IsInRole("General Store"))
            {
                ModuleList = _db.ModuleMsts.Where(a => a.IsActive == 1 && a.pk_moduleid==3).ToList();
            }
            else
            {
                ModuleList = _db.ModuleMsts.Where(a => a.IsActive == 1 && a.pk_moduleid == 1).ToList();
            }
            return View(ModuleList);
        }

    }
}