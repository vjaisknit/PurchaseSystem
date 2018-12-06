using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurchaseSystem.Common
{
    public static class CustomRoles
    {
        public const string Admin = "Admin";
        public const string GS = "General Store";
        public const string CS = "Cloth Store";
        public const string Adm_GS = Admin + "," + GS;
        public const string Adm_CS = Admin + "," + CS;
    }
}