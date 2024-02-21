
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBookStore.Common;
using WebBookStore.Models.WebBookStore;

namespace WebBookStore.Areas.Admin.Controllers
{
    public class CNTT1_10_adminController : BaseController
    {
        static string thongbao = "";
        // GET: Admin/CNTT1_10_admin
        private WBSDbContext db;
        public int getLastProduct()
        {
            using (db = new WBSDbContext())
            {
                var LastId = 0;
                try
                {
                    LastId = db.DANHMUCSACHes
                    .OrderByDescending(q => q.ID)
                    .Select(q => q.ID)
                    .First();
                }
                catch
                {

                }
                return LastId + 1;
            }
        }

        [HasCredential(RoleID = "VIEW_CATEGORY")]
        public ActionResult Index()
        {
            using (db = new WBSDbContext())
            {
                ViewBag.thongbao = thongbao;
                var model = new DANHMUCSACH();
                ViewBag.Category = db.DANHMUCSACHes.ToList();
                ViewBag.LastId = getLastProduct();
                thongbao = "";
                return View(model);
            }

        }

        [HasCredential(RoleID = "EDIT_CATEGORY")]
        public ActionResult Edit(int ID)
        {
            using (db = new WBSDbContext())
            {
                var model = db.DANHMUCSACHes.Single(p => p.ID == ID);
                ViewBag.Category = db.DANHMUCSACHes.ToList();
                ViewBag.LastId = getLastProduct();
                return View("Index", model);
            }
        }

        [HasCredential(RoleID = "ADD_CATEGORY")]
        [HttpPost]
        public ActionResult Insert(DANHMUCSACH danhmuc)
        {
            using (db = new WBSDbContext())
            {
                db.DANHMUCSACHes.Add(danhmuc);
                db.SaveChanges();
                ViewBag.Category = db.DANHMUCSACHes.ToList();
                ViewBag.LastId = getLastProduct();
                return RedirectToAction("Index");
            }
        }

        [HasCredential(RoleID = "EDIT_CATEGORY")]
        public ActionResult Update(DANHMUCSACH danhmuc)
        {
            using (db = new WBSDbContext())
            {
                var model = db.DANHMUCSACHes.Single(p => p.ID == danhmuc.ID);
                model.TenDMSach = danhmuc.TenDMSach;
                db.SaveChanges();
                ViewBag.Category = db.DANHMUCSACHes.ToList();
                return RedirectToAction("Index");
            }
        }

        [HasCredential(RoleID = "DELETE_CATEGORY")]
        public ActionResult Delete(int ID)
        {
            using (db = new WBSDbContext())
            {
                var model = db.DANHMUCSACHes.Single(p => p.ID == ID);
                try
                {
                    db.DANHMUCSACHes.Remove(model);
                    db.SaveChanges();
                    ViewBag.Category = db.DANHMUCSACHes.ToList();
                }
                catch (Exception e)
                {
                    thongbao = "Yêu Cầu Xoá Các Sản Phẩm Liên Quan Trước Khi Xoá";
                }
                return RedirectToAction("Index");
            }
        }

        [HasCredential(RoleID = "DELETE_CATEGORY")]
        public ActionResult DeleteSelected(int[] ids)
        {
            using (db = new WBSDbContext())
            {
                var items = "";
                foreach (int item in ids)
                {
                    var model = db.DANHMUCSACHes.Single(p => p.ID == item);
                    items += model.TenDMSach + ", ";
                    db.DANHMUCSACHes.Remove(model);
                    db.SaveChanges();
                }
                ViewBag.Category = db.DANHMUCSACHes.ToList();
                return RedirectToAction("Index");
            }
        }
    }
}