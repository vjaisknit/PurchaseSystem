
using PurchaseSystem.Common;
using PurchaseSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PurchaseSystem.Controllers
{
    public class productTypeController : Controller
    {
        ApplicationDbContext _db;
        public productTypeController()
        {
            _db = new ApplicationDbContext();
        }

       [HttpGet]
        public ActionResult Create()
        {
             
            return View("CreateUpdateForm");
        }

        [HttpPost]
        public ActionResult CreateUpdateForm(ProductTypeMst PT)
        {
            if(PT.pk_prodtypeid==0)
            {
                _db.ProductTypeMsts.Add(PT);
                _db.SaveChanges();
            }
            else
            {
                var productTypeInDB = _db.ProductTypeMsts.FirstOrDefault(a => a.pk_prodtypeid == PT.pk_prodtypeid);
                productTypeInDB.Description = PT.Description;
                _db.SaveChanges();
            }
            
            return RedirectToAction("ProductTypeList");
        }

        public ActionResult ProductTypeList()
        {
            var prodList = _db.ProductTypeMsts.ToList();
            return View(prodList);
        }

        public ActionResult Edit(int id)
        {
            var productType = _db.ProductTypeMsts.FirstOrDefault(a => a.pk_prodtypeid == id);
            return View("CreateUpdateForm",productType);
        }
        
    }
}