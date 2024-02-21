using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBookStore.Common;

namespace WebBookStore.Areas.Admin.Controllers
{
    public class RevenueController : BaseController
    {
        // GET: Admin/Revenue
        [HasCredential(RoleID = "VIEW_REVENUE")]
        public ActionResult Index()
        {
            return View();
        }

        [HasCredential(RoleID = "VIEW_REVENUE")]
        public ActionResult ByProduct()
        {
            return View("Index");
        }

        [HasCredential(RoleID = "VIEW_REVENUE")]
        public ActionResult ByCategory()
        {
            return View("Index");
        }

        [HasCredential(RoleID = "VIEW_REVENUE")]
        public ActionResult BySupplier()
        {
            return View("Index");
        }

        [HasCredential(RoleID = "VIEW_REVENUE")]
        public ActionResult ByCustomer()
        {
            return View("Index");
        }

        [HasCredential(RoleID = "VIEW_REVENUE")]
        public ActionResult ByYear()
        {
            return View("Index");
        }

        [HasCredential(RoleID = "VIEW_REVENUE")]
        public ActionResult ByQuarter()
        {
            return View("Index");
        }

        [HasCredential(RoleID = "VIEW_REVENUE")]
        public ActionResult ByMonth()
        {
            return View("Index");
        }

    }
}