using PurchaseSystem.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurchaseSystem.DTO
{
    public class Com_Bill_DTO
    {
        public int pk_tempbillid { get; set; }

        public int Fk_ProductId { get; set; }

        public double prodQuantity { get; set; }

        public double price { get; set; }

        public CustomerMst CustomerMst { get; set; }

        public IEnumerable<ProductDDD_DTO> ProductList { get; set; }

    }
}