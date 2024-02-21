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
    public class ProductsController : BaseController
    {
        private WBSDbContext db;
        // GET: Admin/Product

        [HasCredential(RoleID = "VIEW_PRODUCT")]
        public ActionResult Index()
        {
            using (db = new WBSDbContext())
            {
                var model = db.SANPHAMs.Include(i => i.NHAXUATBAN).Include(i => i.TACGIA).ToList();
                return View(model);
            }
        }
        public int getLastProduct()
        {
            using (db = new WBSDbContext())
            {
                var LastId = 0;
                try
                {
                    LastId = db.SANPHAMs
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
        // GET: Admin/Product/Details/5
        [HasCredential(RoleID = "VIEW_PRODUCT")]
        public ActionResult Details(int id)
        {
            using (db = new WBSDbContext())
            {
                var model = db.SANPHAMs.Include(i => i.NHAXUATBAN).Include(i => i.TACGIA).Include(i => i.DANHMUCSACH).SingleOrDefault(i => i.ID == id);
                return View("Details", model);
            }
        }

        // GET: Admin/Product/Insert
        [HasCredential(RoleID = "ADD_PRODUCT")]
        public ActionResult Insert()
        {
            using (db = new WBSDbContext())
            {
                ViewBag.Category = db.DANHMUCSACHes.ToList();
                ViewBag.Suplier = db.NHAXUATBANs.ToList();
                ViewBag.Author = db.TACGIAs.ToList();
                ViewBag.LastId = getLastProduct();
                return View();
            }
        }

        [HasCredential(RoleID = "ADD_PRODUCT")]
        // POST: Admin/Product/Insert
        [HttpPost]
        public ActionResult Insert(SANPHAM model, HttpPostedFileBase file)
        {
            try
            {
                // TODO: Add insert logic here
                using (db = new WBSDbContext())
                {
                    if (file != null)
                    {
                        if (file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var upload = Path.Combine(Server.MapPath("~/Assets/images"), fileName);
                            file.SaveAs(upload);
                        }
                        var pathhinh = file.FileName;
                        model.Anh = pathhinh;
                    }
                    else
                    {
                        
                        model.Anh = "None";
                    }

                    db.SANPHAMs.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Products", new { area = "Admin" });
                }
            }
            catch
            {
                return View();
            }
        }

        [HasCredential(RoleID = "EDIT_PRODUCT")]
        // GET: Admin/Product/Edit/5
        public ActionResult Edit(int id)
        {
            using (db = new WBSDbContext())
            {
                ViewBag.Category = db.DANHMUCSACHes.ToList();
                ViewBag.Suplier = db.NHAXUATBANs.ToList();
                ViewBag.Author = db.TACGIAs.ToList();
                var model = db.SANPHAMs.Include(p => p.NHAXUATBAN).Include(p => p.TACGIA).Include(p => p.DANHMUCSACH).SingleOrDefault(p => p.ID == id);
                return View(model);
            }
        }

        // POST: Admin/Product/Edit/5
        [HasCredential(RoleID = "EDIT_PRODUCT")]
        [HttpPost]
        public ActionResult Update(SANPHAM model, FormCollection collection, HttpPostedFileBase file)
        {
            try
            {
                // TODO: Add update logic here
                using (db = new WBSDbContext())
                {
                    string pathAnh;
                    SANPHAM product = db.SANPHAMs.SingleOrDefault(p => p.ID == model.ID);
                    if (file != null)
                    {
                        if (file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var upload = Path.Combine(Server.MapPath("~/Assets/images"), fileName);
                            file.SaveAs(upload);
                            pathAnh = file.FileName;
                        }
                        else
                        {
                            pathAnh = model.Anh;
                        }
                        product.Anh = pathAnh;
                    }
                    product.TenSanPham = model.TenSanPham;
                    product.MaNXB = model.MaNXB;
                    product.GiaSanPham = model.GiaSanPham;
                    product.NgaySanXuat = model.NgaySanXuat;
                    product.MaDMSach = model.MaDMSach;
                    product.SoLuong = model.SoLuong;
                    product.KhuyenMai = model.KhuyenMai;
                    product.MoTa = model.MoTa;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        [HasCredential(RoleID = "DELETE_PRODUCT")]
        // GET: Admin/Product/Delete/5
        public ActionResult Delete(int id)
        {
            using (db = new WBSDbContext())
            {
                var model = db.SANPHAMs.SingleOrDefault(p => p.ID == id);
                db.SANPHAMs.Remove(model);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HasCredential(RoleID = "DELETE_PRODUCT")]
        public ActionResult DeleteSelected(int[] ids)
        {
            using (db = new WBSDbContext())
            {
                var items = "";
                foreach (int item in ids)
                {
                    var model = db.SANPHAMs.SingleOrDefault(p => p.ID == item);
                    items += model.TenSanPham + ", ";
                    db.SANPHAMs.Remove(model);
                    db.SaveChanges();
                }
                ViewBag.Category = db.SANPHAMs.ToList();
                return RedirectToAction("Index");
            }
        }
    }
}
