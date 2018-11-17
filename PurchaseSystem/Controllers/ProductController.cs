using PurchaseSystem.DTO;
using PurchaseSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PurchaseSystem.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Product

        [HttpGet]
        public ActionResult AddUpdateProduct()
        {
            var pageLoadData = new ProductMstDTO
            {
                ProductTypeMstList = _db.ProductTypeMsts.ToList()
            };
            return View(pageLoadData);
        }

        public ActionResult ProductList()
        {
           
            return View(_db.ProductMsts.ToList());
        }
        [HttpPost]
        public ActionResult AddUpdateProduct(ProductMstDTO product)
        {
            _db.ProductMsts.Add(product.productMst);
            _db.SaveChanges();
            return RedirectToAction("ProductList");
        }



    }
}