using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodaSupportWeb.Models;
using TodaWebDB;

namespace TodaSupportWeb.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModels model)
        {
            AccountModels account = new AccountModels();
            account.RegisterUser(model.Username,model.Name,model.PhoneNumber,model.Email,model.Password);
            return View(model);
        }
    }
}