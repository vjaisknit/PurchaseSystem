using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurchaseSystem.DTO
{
    public class ProductListDTO
    {
        public int pk_ProductId { get; set; }

        public string productType { get; set; }

        public string ProductName { get; set; }

        public double oriPrice { get; set; }

        public double sellingUpToPrice { get; set; }

        public double productQuantity { get; set; }
    }
}