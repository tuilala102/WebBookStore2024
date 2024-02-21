using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBookStore.Models.WebBookStore;
using WebBookStore.Areas.Admin.Models;

namespace WebBookStore.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        WBSDbContext db = new WBSDbContext();
        // GET: Admin/Home
        public ActionResult Index()
        {
            db = new WBSDbContext();
            ViewBag.DonHang = 0; // db.DONHANGs.Where(x => x.NgayDatHang.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd") && x.TinhTrang > 0).ToList().Count();
            ViewBag.KhachHang = db.NGUOIDUNGs.ToList().Count();
            ViewBag.SanPham = db.SANPHAMs.ToList().Count();
            ViewBag.NhaCungCap = db.NHAXUATBANs.ToList().Count();
            List<DataChart> dataChart = new List<DataChart>();
            ViewBag.DataChart = dataChart;
            return View();
        }
    }
}