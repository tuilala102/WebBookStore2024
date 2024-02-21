using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBookStore.Models.WebBookStore;
using System.Data.Entity;
using PagedList;

namespace WebBookStore.Controllers
{
    public class CNTT1_10Controller : Controller
    {
        // GET: CNTT1_10
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
            }
            else
            {
                ViewBag.DaXem = list;
            }

            return View("Detail", model);
        }
    }
}