using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBookStore.Models.UtilsModel;
using WebBookStore.Dao;
using WebBookStore.Common;
using WebBookStore.Models.WebBookStore;

namespace WebBookStore.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Admin/Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            Session[CommonConstants.SESSION_CREDENTIALS] = null;
            return RedirectToAction("Login", "Account", new { area = "Admin" });
        }


        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var res = dao.Login(model.Email, Encryptor.MD5Hash(model.MatKhau));
                if (res == 1)
                {
                    var user = dao.GetByEmail(model.Email);
                    if (user.MaNhom != CommonConstants.CUSTOMER_GROUP)
                    {
                        var userSession = new UserLogin();
                        userSession.Email = user.Email;
                        userSession.ID = user.ID;
                        userSession.MaNhom = user.MaNhom;
                        var listCredentials = dao.GetListCredential(model.Email);
                        Session.Add(CommonConstants.SESSION_CREDENTIALS, listCredentials);
                        Session.Add(CommonConstants.USER_SESSION, userSession);
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    } else
                    {
                        ModelState.AddModelError("", "Tài khoản không có quyền truy cập.");
                    }
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
            return View("Index");
        }
    }
}