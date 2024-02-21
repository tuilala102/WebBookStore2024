using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBookStore.Models.WebBookStore;
using WebBookStore.Models;
using System.Web.Script.Serialization;
using WebBookStore.Common;
using System.IO;
using WebBookStore.Dao;

namespace WebBookStore.Controllers
{
    public class CartController : BaseController
    {
        private string CartSession = "ttt";
        double tongca=0;
        int soluongca = 0;
        public ActionResult Index()
        {
            double tong = 0;
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            foreach (CartItem i in list)
            {
                tong = ((double)(tong + i.product.GiaSanPham * i.Quantity * (1 - i.product.KhuyenMai)));
            }
            ViewBag.tong = tong;
            return View(list);
        }
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.product.ID == item.product.ID);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.product.ID == id);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        public ActionResult AddItem(int productId, int quantity)
        {
            var session = (UserLogin)Session[WebBookStore.Common.CommonConstants.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("Login", "User");
            }


            WBSDbContext db;
            db = new WBSDbContext();
            var product = db.SANPHAMs.Find(productId);

            var cart = Session[CartSession];
            if (cart != null)
            {

                var list = (List<CartItem>)cart;

                if (list.Exists(x => x.product.ID == productId))
                {


                    foreach (var item in list)
                    {
                        if (item.product.ID == productId)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                Session[CartSession] = list;
            }
            else
            {
                var item = new CartItem();
                item.product = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                Session[CartSession] = list;


            }
            return RedirectToAction("Index");
        }
         [HttpGet]
        public ActionResult Payment()
        {
             double tong = 0;
            int soluong = 0;
            var cart = Session[CartSession];
            var session = (UserLogin)Session[WebBookStore.Common.CommonConstants.USER_SESSION];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            foreach (CartItem i in list)
            {
                tong = ((double)(tong + i.product.GiaSanPham * i.Quantity * (1 - i.product.KhuyenMai)));
                soluong = soluong + i.Quantity;
            }
            ViewBag.tong = tong;
           
           


            return View(list);
        }
        
        public string SinhMaVanDon()
        {


            string str = "PLAT_";
            var rand = new Random();
            for (int i = 0; i < 5; i++)
            {
                char s = (char)('A' + rand.Next(0, 24));
                str.Append(s);
            }

            for (int i = 0; i < 5; i++)
            {
                char s = (char)(rand.Next(0, 9));
                str.Append(s);
            }
            return rand.Next(100000, 999999).ToString();
        }

        [HttpPost]
        public ActionResult Payment(string mota, string diachi)
        {
            try
            {
                double tong = 0;
                int soluong = 0;
                var cart = Session[CartSession];
                var list = new List<CartItem>();
                if (cart != null)
                {
                    list = (List<CartItem>)cart;
                }
                foreach (CartItem i in list)
                {
                    tong = ((double)(tong + i.product.GiaSanPham * i.Quantity * (1 - i.product.KhuyenMai)));
                    soluong = soluong + i.Quantity;
                } 
                var session = (UserLogin)Session[WebBookStore.Common.CommonConstants.USER_SESSION];
                var order = new DONHANG();
                order.NgayDatHang = DateTime.Now;
         
                order.MoTa = mota;
                
                order.DiaChi = diachi;
                order.MaVanDon = SinhMaVanDon();
                order.EmailNguoiNhan = session.Email;
                order.MaKhachHang = (int?)session.ID;
                order.SoLuong = soluong;
                order.TongTien = tong;
                order.TinhTrang = 0;
                var id = new OrderDao().insert(order);
            }
            catch (Exception ex)
            {
                throw;
            }

            return Redirect("/hoan-thanh");
        }
        public ActionResult Success()
        {
            return View();
        }
    }
}