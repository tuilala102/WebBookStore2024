using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using WebBookStore.Models.WebBookStore;
using PagedList;
namespace WebBookStore.Controllers
{
    public class HomeController : Controller
    {
        WBSDbContext db;

        public ActionResult CategoryHome()
        {
            db = new WBSDbContext();
            var model = db.DANHMUCSACHes.ToList();
            return PartialView(model);
        }

        public ActionResult HeaderHome()
        {
            db = new WBSDbContext();
            var model = db.SANPHAMs.ToList();
            return PartialView(model);
        }

        
        public ActionResult FeedbackHome()
        {
            db = new WBSDbContext();
            var model = db.SANPHAMs.ToList();
            return PartialView(model);
        }
        public ActionResult SaleOffHome()
        {
            db = new WBSDbContext();
            var randomProducts = (from p in db.SANPHAMs where p.KhuyenMai>0 orderby Guid.NewGuid() select p).Take(3).ToList();


            return PartialView(randomProducts);
        }
        public ActionResult SpecialHome()
        {
            db = new WBSDbContext();
            var randomProducts = (from p in db.SANPHAMs where p.DacBiet==true orderby Guid.NewGuid() select p).Take(4).ToList();


            return PartialView(randomProducts);
        }

        public ActionResult Index()
        {
            db = new WBSDbContext();
            var model = db.DANHMUCSACHes.Include(u => u.SANPHAMs).ToList();

            var randomProducts = (from p in db.SANPHAMs orderby Guid.NewGuid() select p).Take(5).ToList();
            ViewBag.RandomProducts = randomProducts;

            return View(model);
        }
        public ActionResult DanhSachSanPham()
        {
            db = new WBSDbContext();
            var model = db.DANHMUCSACHes.Include(u => u.SANPHAMs).ToList();

            var randomProducts = (from p in db.SANPHAMs orderby Guid.NewGuid() select p).ToList();
            ViewBag.RandomProducts = randomProducts;

            return PartialView(model);
        }
        public ActionResult TimKiemSanPham(String keywork, int page = 1, int pagesize = 12)

        {
            WBSDbContext db;
            db = new WBSDbContext();
            if (keywork == null) keywork = "";
            ViewBag.Search = keywork;


            var model = from s in db.SANPHAMs.ToList()
                        where (  s.TenSanPham.ToLower().Contains(keywork.ToLower()))
                        select s;


            // return View(students.ToPagedList(pageNumber, pageSize));
            return View("TimKiemSanPham", model.OrderByDescending(x => x.ID).ToPagedList(page, pagesize));
        }
    }
}