using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PurchaseSystem.Common
{
    public class ProductMst
    {
        [Key]
        public int pk_ProductId { get; set; }

        public int fk_prodtypeid { get; set; }

        public string ProductName { get; set; }

        public double oriPrice { get; set; }

        public double sellingUpToPrice { get; set; }

        public double productQuantity { get; set; }

    }
}