using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBookStore.Models.WebBookStore;
using System.Data.Entity;
using PagedList;
using WebBookStore.Common;

namespace WebBookStore.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        WBSDbContext db;
        static List<SANPHAM> list = new List<SANPHAM>();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(int ID)
        {
            db = new WBSDbContext();
            SANPHAM model = db.SANPHAMs.Include(u => u.DANHMUCSACH).Include(u => u.NHAXUATBAN).SingleOrDefault(u => u.ID == ID);
            model.LuotXem++;
            db.SaveChanges();
            ViewBag.GiaKM = model.GiaSanPham * (1 - model.KhuyenMai);

            ViewBag.DanhGia = db.DANHGIAs.Where(u => u.MaSanPham == ID).ToList();

            bool exist = false;
            foreach (var x in list)
            {
                if (x.ID == ID)
                {
                    exist = true;
                    break;
                }
            }
            if (exist == false)
            {
                list.Add(model);
            }

            if (list.Count > 8)
            {
                ViewBag.DaXem = list.Skip(list.Count - 8);
            } else
            {
                ViewBag.DaXem = list;
            }

            return View("Detail", model);
        }
        public ActionResult SanPhamHeader(string Id, int page=1, int pageSize=12)
        {

            db = new WBSDbContext();
            List<WebBookStore.Models.WebBookStore.SANPHAM> model = null;
            switch (Id)
            {
                case "Best":
                   model = db.SANPHAMs.Include(u => u.LuotXem).Include(u => u.DANHMUCSACH).ToList();
                    ViewBag.Id = Id;

                    break;
                case "Latest":
                     model = db.SANPHAMs.Include(u => u.LuotXem).Include(u => u.DANHMUCSACH)
                        .Where(p => (bool)p.Moi).ToList();
                    ViewBag.Id = Id;

                    break;
                case "Special":
                    model = db.SANPHAMs.Where(p => p.DacBiet == true).OrderByDescending(x => x.ID).ToList();
                    ViewBag.Id = Id;
                    break;
                case "SalesOff":
                    model = db.SANPHAMs.Where(p => p.KhuyenMai> 0).OrderByDescending(p => p.KhuyenMai).ToList();
                    ViewBag.Id = Id;
                    break;
                case "Favorite":
                    model = db.SANPHAMs.Include(u => u.LuotXem).Include(u => u.DANHMUCSACH).ToList();
                    ViewBag.Id = Id;
                    break;
                case "Views":
                    model = db.SANPHAMs.Include(u => u.LuotXem).Include(u => u.DANHMUCSACH).Take(12).ToList();
                    ViewBag.Id = Id;
                    break;


                default:
                    model = db.SANPHAMs.Include(u => u.LuotXem).Include(u => u.DANHMUCSACH).ToList();
                    ViewBag.Id = Id;
                    break;
            }
            ViewBag.sosp = model.Count();
            return View("SanPhamHeader", model.OrderByDescending(x => x.ID).ToPagedList(page, pageSize));
        }

        public ActionResult HienThiTheoLoaiSach(int Id, int page=1, int pageSize=12)
        {
           
            db = new WBSDbContext();
            var model = db.DANHMUCSACHes.Include(u => u.SANPHAMs).SingleOrDefault(u => u.ID== Id).SANPHAMs.ToList();
            ViewBag.sosp = model.Count();    
            return View("HienThiTheoLoaiSach", model.OrderByDescending(x => x.ID).ToPagedList(page, pageSize));
        }

        public ActionResult TimKiemSanPham(String keywork, int page = 1, int pagesize = 12)
        {
            WBSDbContext db;
            db = new WBSDbContext();
            ViewBag.tukhoa = keywork;


            var model = from s in db.SANPHAMs.Include(u => u.DANHMUCSACH).Include(u => u.NHAXUATBAN).ToList()
                        where ((string.IsNullOrEmpty(keywork) ? true : s.TenSanPham.ToLower().Contains(keywork.ToLower())))
                        select s;

            return View("TimKiemSanPham", model.OrderByDescending(x => x.ID).ToPagedList(page, pagesize));
        }

    }
}