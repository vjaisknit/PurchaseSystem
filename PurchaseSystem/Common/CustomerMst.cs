using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PurchaseSystem.Common
{
    public class CustomerMst
    {
        [Key]
        public int pk_Custid { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string MobNo { get; set; }
    }
}