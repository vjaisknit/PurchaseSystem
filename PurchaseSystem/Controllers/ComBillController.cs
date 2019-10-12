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

        public Com_Bill_DTO GetPageData()
        {
            Com_Bill_DTO comBill = new Com_Bill_DTO();
            if (User.IsInRole("Admin"))
            {
                var prodList = from productList in _db.ProductMsts
                               select new ProductDDD_DTO
                               {
                                   productId = productList.pk_ProductId,
                                   ProductName = productList.ProductName
                               };
                comBill.ProductList = prodList.ToList();

            }
            else
            {
                var prodList = from productList in _db.ProductMsts
                               where productList.username == User.Identity.Name
                               select new ProductDDD_DTO
                               {
                                   productId = productList.pk_ProductId,
                                   ProductName = productList.ProductName
                               };
                comBill.ProductList = prodList.ToList();
            }

            return comBill;
        }


        public JsonResult GetProductList(string productName)
        {
            IEnumerable<ProductDDD_DTO> prodList = new List<ProductDDD_DTO>();
            if (User.IsInRole("Admin"))
            {
                prodList = from productList in _db.ProductMsts
                           where productList.ProductName.Contains(productName)
                           select new ProductDDD_DTO
                           {
                               productId = productList.pk_ProductId,
                               ProductName = productList.ProductName
                           };



            }
            else
            {
                prodList = from productList in _db.ProductMsts
                           where productList.ProductName.Contains(productName) 
                           select new ProductDDD_DTO
                           {
                               productId = productList.pk_ProductId,
                               ProductName = productList.ProductName
                           };
            }
            return Json(prodList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CalculatePrice(int selectedProductId, double countOrWeight)
        {
            ProductMst product = _db.ProductMsts.FirstOrDefault(a => a.pk_ProductId == selectedProductId);
            double price = countOrWeight * product.sellingUpToPrice;

            return Json(price, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult SaveUpdateBill(int id)
        {
            Com_Bill_DTO item = new Com_Bill_DTO();
            CustomerMst cust;
            if (User.IsInRole("Admin"))
            {
                cust = _db.CustomerMsts.FirstOrDefault(a => a.pk_Custid == id);
            }
            else
            {
                cust = _db.CustomerMsts.FirstOrDefault(a => a.pk_Custid == id && a.Username == User.Identity.Name);
            }
            item = GetPageData();
            item.CustomerMst = cust;
            return View(item);
        }
        [HttpPost]
        public ActionResult SaveUpdateBill(Com_Bill_DTO billData)
        {
            ProductListForBill productDetail = new ProductListForBill();
            productDetail.username = User.Identity.Name;
            productDetail.fk_custId = billData.CustomerMst.pk_Custid;
            productDetail.Fk_ProductId = billData.Fk_ProductId;
            productDetail.productQuantity = billData.prodQuantity;
            productDetail.price = billData.price;
            _db.ProductListForBills.Add(productDetail);
            _db.SaveChanges();
            return View();

        }
    }
}