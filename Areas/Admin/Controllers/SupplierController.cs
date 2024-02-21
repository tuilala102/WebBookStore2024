using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBookStore.Models.WebBookStore;
using System.Data.Entity;
using System.IO;
using WebBookStore.Common;

namespace WebBookStore.Areas.Admin.Controllers
{
    public class SupplierController : BaseController
    {
        static string thongbao = "";
        private WBSDbContext db;
        // GET: Admin/Suplier

        [HasCredential(RoleID = "VIEW_SUPPLIER")]
        public ActionResult Index()
        {
            using (db = new WBSDbContext())
            {
                ViewBag.thongbao = thongbao;
                var model = new NHAXUATBAN();
                ViewBag.Supplier = db.NHAXUATBANs.ToList();
                ViewBag.LastId = getLastsupplier();
                thongbao = "";
                return View(model);
            }

        }
        public int getLastsupplier()
        {
            using (db = new WBSDbContext())
            {
                var LastId = 0;
                try
                {
                    LastId = db.NHAXUATBANs
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

        [HasCredential(RoleID = "ADD_SUPPLIER")]
        [HttpPost]
        public ActionResult Insert(NHAXUATBAN NXB)
        {

            try
            {

                if (ModelState.IsValid)
                {
                    using (db = new WBSDbContext())
                    {
                        db.NHAXUATBANs.Add(NXB);
                        db.SaveChanges();
                        ViewBag.Category = db.NHAXUATBANs.ToList();
                        ViewBag.LastId = getLastsupplier();

                    }
                }
                else
                {
                    ModelState.AddModelError("", "error: ");
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "error: " + e.InnerException);

                

            }
            return RedirectToAction("Index");
            // return View("Index");

        }

        [HasCredential(RoleID = "EDIT_SUPPLIER")]
        public ActionResult Edit(int id)
        {
            using (db = new WBSDbContext())
            {
                var model = db.NHAXUATBANs.SingleOrDefault(p => p.ID == id);
                ViewBag.Supplier = db.NHAXUATBANs.ToList();
                return View("Index", model);
            }
        }

        [HasCredential(RoleID = "EDIT_SUPPLIER")]
        public ActionResult Update(NHAXUATBAN model, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                using (db = new WBSDbContext())
                {
                    NHAXUATBAN supplier = db.NHAXUATBANs.SingleOrDefault(p => p.ID == model.ID);
                    supplier.TenNXB = model.TenNXB;
                    supplier.DiaChi = model.DiaChi;
                    supplier.Email = model.Email;
                    supplier.SDT = model.SDT;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        [HasCredential(RoleID = "DELETE_SUPPLIER")]
        public ActionResult Delete(int ID)
        {
            using (db = new WBSDbContext())
            {
                var model = db.NHAXUATBANs.SingleOrDefault(p => p.ID == ID);
                try
                {
                    db.NHAXUATBANs.Remove(model);
                    db.SaveChanges();
                    ViewBag.Supplier = db.NHAXUATBANs.ToList();
                } catch  (Exception e)
                {
                    thongbao = "Yêu Cầu Xoá Các Sản Phẩm Liên Quan Trước Khi Xoá";
                }
                return RedirectToAction("Index");
            }
        }

        [HasCredential(RoleID = "DELETE_SUPPLIER")]
        public ActionResult DeleteSelected(int[] ids)
        {
            using (db = new WBSDbContext())
            {
                var items = "";
                foreach (int item in ids)
                {
                    var model = db.NHAXUATBANs.Single(p => p.ID == item);
                    items += model.TenNXB + ", ";
                    db.NHAXUATBANs.Remove(model);
                    db.SaveChanges();
                }
                ViewBag.Category = db.NHAXUATBANs.ToList();
                return RedirectToAction("Index");
            }
        }
    }
}