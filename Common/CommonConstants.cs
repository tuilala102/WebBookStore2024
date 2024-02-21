using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBookStore.Common
{
    public static class CommonConstants
    {
        public static string ADMIN_GROUP = "ADMIN";
        public static string STOCKKEEPER_GROUP = "STOCKKEEPER";
        public static string ACCOUNTANT_GROUP = "ACCOUNTANT";
        public static string CUSTOMER_GROUP = "CUSTOMER";

        public static string USER_SESSION = "USER_SESSION";
        public static string SESSION_CREDENTIALS = "SESSION_CREDENTIALS";
        public static string CART_SESSION = "CART_SESSION";
        public static string CurrentCulture { set; get; }
    }
}