using PurchaseSystem.Common;
using PurchaseSystem.DTO;
using PurchaseSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PurchaseSystem.Controllers
{
    public class ComBillController : Controller
    {
        ApplicationDbContext _db;

        public ComBillController()
        {
            _db = new ApplicationDbContext();
        }
        // GET: ComBill
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
       public ActionResult SaveUpdateBill(int id)
        {
            Com_Bill_DTO item = new Com_Bill_DTO();
            CustomerMst cust;
                if(User.IsInRole("Admin"))
            {
                cust = _db.CustomerMsts.FirstOrDefault(a => a.pk_Custid == id);
            }
            else
            {
                cust = _db.CustomerMsts.FirstOrDefault(a => a.pk_Custid == id && a.Username==User.Identity.Name);
            }
            item.CustomerMst = cust;
            return View(item);
        }


    }
}