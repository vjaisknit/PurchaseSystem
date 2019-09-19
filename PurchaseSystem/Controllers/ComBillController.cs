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
            
           return comBill;
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


    }
}