using System;
using System.Linq;
using System.Web.Mvc;
using WebBookStore.Models.WebBookStore;
using System.Data.Entity;
using WebBookStore.Areas.Admin.Models.SearchOrder;
using WebBookStore.Common;

namespace WebBookStore.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {

        // GET: Admin/Order
        private WBSDbContext db;

        [HasCredential(RoleID = "VIEW_ORDER")]
        public ActionResult Index()
        {
            using (db = new WBSDbContext())
            {
                ViewBag.Status = "0";
                var order = db.DONHANGs.Include(u => u.CHITIETDONHANGs).Include(u => u.NGUOIDUNG).Where(u => u.TinhTrang == 0).ToList();
                ViewBag.Orders = order;
                return View();
            }
        }
        public long getTotal(int ID)
        {
            using (db = new WBSDbContext())
            {
                var detailOrder = db.CHITIETDONHANGs.Where(u => u.MaDonHang == ID).ToList();
                long total = 0;
                foreach (CHITIETDONHANG item in detailOrder)
                {
                    for (int i = 0; i < item.SoLuong; i++)
                    {
                        total += (long)item.DonGia;
                    }
                }
                return total;
            }
        }
        public ActionResult Filter()
        {
            using (db = new WBSDbContext())
            {
                var order = db.DONHANGs.Include(u => u.CHITIETDONHANGs).Include(u => u.NGUOIDUNG).ToList();
                ViewBag.DateStart = "";
                ViewBag.DateEnd = "";
                ViewBag.Status = "";
                SearchOrder searchOrder = new SearchOrder();
                if (!string.IsNullOrEmpty(Request.Params["Status"].ToString()))
                {
                    ViewBag.Status = Request.Params["Status"].ToString();
                    searchOrder.Status = Convert.ToInt32(Request.QueryString["Status"].ToString());
                    order = order.Where(x => x.TinhTrang == searchOrder.Status).ToList();
                }
                if (!string.IsNullOrEmpty(Request.QueryString["DateStart"].ToString()))
                {
                    ViewBag.DateStart = Request.QueryString["DateStart"].ToString();
                    searchOrder.DateStart = Request.QueryString["DateStart"].ToString();
                    order = order.Where(x => x.NgayDatHang.Value.ToString("yyyy-MM-dd").CompareTo(Request.QueryString["DateStart"].ToString()) >= 0).ToList();
                }
                if (!string.IsNullOrEmpty(Request.QueryString["DateEnd"].ToString()))
                {
                    ViewBag.Status = Request.QueryString["DateEnd"].ToString();
                    searchOrder.DateEnd = Request.QueryString["DateEnd"].ToString();
                    order = order.Where(x => x.NgayNhanHang.Value.ToString("yyyy-MM-dd").CompareTo(Request.QueryString["DateEnd"].ToString()) < 0).ToList();
                }
                ViewBag.Orders = order;
                return View("Index");
            }
        }

        [HasCredential(RoleID = "VIEW_ORDER")]
        public ActionResult Detail(int id)
        {
            using (db = new WBSDbContext())
            {
                var order = db.DONHANGs.Include(u => u.NGUOIDUNG).Include(u => u.CHITIETDONHANGs).SingleOrDefault(u => u.ID == id);
                ViewBag.Total = getTotal(id);
                db = new WBSDbContext();
                ViewBag.OrderDetail = db.CHITIETDONHANGs.Include(u => u.SANPHAM).Where(u => u.MaDonHang == id);
                return View(order);
            }
        }
        [HttpPost]
        public ActionResult SetStatusOrder(FormCollection form)
        {
            using (db = new WBSDbContext())
            {
                int status = Convert.ToInt32(form["idorder"]);
                var order = db.DONHANGs.Where(u => u.ID == status).SingleOrDefault();
                order.TinhTrang = int.Parse(form["status"]);
                db.SaveChanges();
                return RedirectToAction("Index", "Order");
            }
        }

        [HasCredential(RoleID = "DELETE_ORDER")]
        public ActionResult Delete(int id)
        {
            using (db = new WBSDbContext())
            {
                var order = db.DONHANGs.SingleOrDefault(u => u.ID == id);
                order.TinhTrang = -1;
                db.SaveChanges();
                ViewBag.Total = getTotal(id);
                return RedirectToAction("Index", "Order");
            }
        }
        
    }
}