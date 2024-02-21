using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBookStore.Common;
using WebBookStore.Models.WebBookStore;

namespace WebBookStore.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        WBSDbContext db = new WBSDbContext();
        // GET: Admin/User
        [HasCredential(RoleID = "VIEW_USER")]
        public ActionResult Index()
        {
            var model = db.NGUOIDUNGs.ToList();
            return View(model);
        }
        public int getLastProduct()
        {
            var LastId = 0;
            try
            {
                LastId = db.NGUOIDUNGs
                .OrderByDescending(q => q.ID)
                .Select(q => q.ID)
                .First();
            }
            catch
            {

            }
            return LastId + 1;
        }
        // GET: Admin/Product/Details/5
        [HasCredential(RoleID = "VIEW_USER")]
        public ActionResult Details(int id)
        {
            var model = db.NGUOIDUNGs.SingleOrDefault(i => i.ID == id);
            return View("Details", model);
        }

        // GET: Admin/Product/Insert
        [HasCredential(RoleID = "ADD_USER")]
        public ActionResult Insert()
        {
            ViewBag.TrangThai = new List<string> { "0", "1" };
            ViewBag.NhomND = db.NHOMNDs.ToList();
            ViewBag.LastId = getLastProduct();
            return View();
        }

        [HasCredential(RoleID = "ADD_USER")]
        // POST: Admin/Product/Insert
        [HttpPost]
        public ActionResult Insert(NGUOIDUNG model)
        {
            try
            {
                db.NGUOIDUNGs.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index", "User", new { area = "Admin" });
            }
            catch
            {
                return View();
            }
        }

        [HasCredential(RoleID = "EDIT_USER")]
        // GET: Admin/Product/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.TrangThai = new List<string> { "0", "1" };
            ViewBag.NhomND = db.NHOMNDs.ToList();
            var model = db.NGUOIDUNGs.SingleOrDefault(p => p.ID == id);
            return View(model);
        }

        // POST: Admin/Product/Edit/5
        [HasCredential(RoleID = "EDIT_USER")]
        [HttpPost]
        public ActionResult Update(NGUOIDUNG model, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                using (db = new WBSDbContext())
                {
                    NGUOIDUNG user = db.NGUOIDUNGs.SingleOrDefault(p => p.ID == model.ID);
                    user.HoVaTen = model.HoVaTen;
                    user.DiaChi = model.DiaChi;
                    user.SDT = model.SDT;
                    user.Email = model.Email;
                    user.TrangThai = model.TrangThai;
                    user.MaNhom = model.MaNhom;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        [HasCredential(RoleID = "DELETE_USER")]
        // GET: Admin/Product/Delete/5
        public ActionResult Delete(int id)
        {
            var model = db.NGUOIDUNGs.SingleOrDefault(p => p.ID == id);
            db.NGUOIDUNGs.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HasCredential(RoleID = "DELETE_USER")]
        public ActionResult DeleteSelected(int[] ids)
        {
            foreach (int item in ids)
            {
                var model = db.NGUOIDUNGs.SingleOrDefault(p => p.ID == item);
                db.NGUOIDUNGs.Remove(model);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}