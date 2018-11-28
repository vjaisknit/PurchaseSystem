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
            var ProductList = from a in _db.ProductMsts
                              join b in _db.ProductTypeMsts on a.fk_prodtypeid equals b.pk_prodtypeid
                              select new ProductListDTO
                              {
                                  pk_ProductId = a.pk_ProductId,
                                  productType = b.Description,
                                  ProductName = a.ProductName,
                                  oriPrice = a.oriPrice,
                                  productQuantity = a.productQuantity,
                                  sellingUpToPrice = a.sellingUpToPrice
                              };

            return View(ProductList);
        }

        public ActionResult Edit(int id)
        {
            var EditData = new ProductMstDTO
            {
                productMst = _db.ProductMsts.FirstOrDefault(a => a.pk_ProductId == id),
                ProductTypeMstList = _db.ProductTypeMsts.ToList()
               
            };
            return View("AddUpdateProduct", EditData);
           
        }

        public ActionResult Delete(int id)
        {
         var dataForDelete= _db.ProductMsts.FirstOrDefault(a => a.pk_ProductId == id);
            _db.ProductMsts.Remove(dataForDelete);
            _db.SaveChanges();
            return RedirectToAction("ProductList");

        }


        [HttpPost]
        public ActionResult AddUpdateProduct(ProductMstDTO product)
        {
            if(product.productMst.pk_ProductId==0)
            {
                _db.ProductMsts.Add(product.productMst);
                _db.SaveChanges();
            }
            else
            {
                var dataInDb= _db.ProductMsts.FirstOrDefault(a => a.pk_ProductId == product.productMst.pk_ProductId);
                dataInDb.fk_prodtypeid = product.productMst.fk_prodtypeid;
                dataInDb.ProductName = product.productMst.ProductName;
                dataInDb.productQuantity = product.productMst.productQuantity;
                dataInDb.sellingUpToPrice = product.productMst.sellingUpToPrice;
                dataInDb.oriPrice = product.productMst.oriPrice;
                _db.SaveChanges();


            }

            return RedirectToAction("ProductList");
        }



    }
}