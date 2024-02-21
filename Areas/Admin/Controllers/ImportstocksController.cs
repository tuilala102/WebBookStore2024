using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBookStore.Common;

namespace WebBookStore.Areas.Admin.Controllers
{
    public class ImportstocksController : BaseController
    {
        // GET: Admin/Importstocks
        [HasCredential(RoleID = "VIEW_STOCK")]
        public ActionResult Index()
        {
            return View();
        }
    }
}