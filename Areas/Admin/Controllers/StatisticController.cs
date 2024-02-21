using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBookStore.Areas.Admin.Models;
using WebBookStore.Common;
using WebBookStore.Models.WebBookStore;

namespace WebBookStore.Areas.Admin.Controllers
{
    public class StatisticController : BaseController
    {
        // GET: Admin/Statistic
        WBSDbContext db = new WBSDbContext();


        [HasCredential(RoleID = "VIEW_STATISTIC")]
        public ActionResult Index()
        {
            return View();
        }


        [HasCredential(RoleID = "VIEW_STATISTIC")]
        public ActionResult ByCategory()
        {
            var model = db.SANPHAMs
                .GroupBy(p => p.DANHMUCSACH)
                .Select(g => new ReportInfo
                {
                    Group = g.Key.TenDMSach,
                    Count = g.Sum(p => p.SoLuong),
                    Sum = g.Sum(p => p.GiaSanPham * p.SoLuong),
                    Min = g.Min(p => p.GiaSanPham),
                    Max = g.Max(p => p.GiaSanPham),
                    Avg = g.Average(p => p.GiaSanPham)
                });
            return View("Index", model);
        }

        [HasCredential(RoleID = "VIEW_STATISTIC")]
        public ActionResult BySupplier()
        {
            var model = db.SANPHAMs
                .GroupBy(p => p.NHAXUATBAN)
                .Select(g => new ReportInfo
                {
                    Group = g.Key.TenNXB,
                    Count = g.Sum(p => p.SoLuong),
                    Sum = g.Sum(p => p.GiaSanPham * p.SoLuong),
                    Min = g.Min(p => p.GiaSanPham),
                    Max = g.Max(p => p.GiaSanPham),
                    Avg = g.Average(p => p.GiaSanPham)
                });
            return View("Index", model);
        }
    }
}