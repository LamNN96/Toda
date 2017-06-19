using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodaSupportWeb.Models;
using TodaWebDB;

namespace TodaSupportWeb.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModels model)
        {
            var result = new AccountModels().Login(model.Username, model.Password);
            if (ModelState.IsValid && result)
            {
                Session["User"] = new AccountModels().GetLoginUser(model.Username, model.Password);
                   return RedirectToAction("Index", "Request");
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không hợp lệ");
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            Session["User"] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}