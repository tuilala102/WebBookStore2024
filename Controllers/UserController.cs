using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBookStore.Models.UtilsModel;
using WebBookStore.Dao;
using WebBookStore.Common;
using WebBookStore.Models.WebBookStore;

namespace WebBookStore.Controllers
{
    public class UserController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return Redirect("/");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var res = dao.Login(model.Email, Encryptor.MD5Hash(model.MatKhau));
                if (res == 1)
                {
                    var user = dao.GetByEmail(model.Email);
                    var userSession = new UserLogin();
                    userSession.Email = user.Email;
                    userSession.ID = user.ID;
                    userSession.MaNhom = CommonConstants.CUSTOMER_GROUP;
                    userSession.SanPhamDaXem = new List<SANPHAM>();
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return Redirect("/");
                }
                else if (res == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                }
                else if (res == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khoá.");
                }
                else if (res == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng.");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng.");
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid) {
                var dao = new UserDao();
                if (dao.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                } else
                {
                    var user = new NGUOIDUNG();
                    user.HoVaTen = model.HoVaTen;
                    user.Email = model.Email;
                    user.SDT = model.SDT;
                    user.MatKhau = Encryptor.MD5Hash(model.MatKhau);
                    user.DiaChi = model.DiaChi;
                    user.TrangThai = 1;
                    user.MaNhom = CommonConstants.CUSTOMER_GROUP;
                    var res = dao.Insert(user);
                    if (res > 0)
                    {
                        ViewBag.Success = "Đăng ký thành công";
                        model = new RegisterModel();
                    } else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công.");
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var dao = new UserDao();
            var user = dao.GetByID(ID);
            RegisterModel model = new RegisterModel();
            model.ID = user.ID;
            model.HoVaTen = user.HoVaTen;
            model.Email = user.Email;
            model.MatKhau = user.MatKhau;
            model.DiaChi = user.DiaChi;
            model.SDT = user.SDT;
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var res = dao.Update(model);
                if (res > 0)
                {
                    ViewBag.Success = "Cập nhật thành công";
                    model = new RegisterModel();
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            return View(model);
        }
    }
}