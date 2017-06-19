using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodaSupportWeb.Models;
using TodaWebDB;

namespace TodaSupportWeb.Controllers
{
    public class RequestController : Controller
    {
        RequestModel rq = new RequestModel();
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["User"] == null)
                return RedirectToAction("Index", "Login");
            ViewBag.PhongBan = new PhongBanKhachHangModels().GetPhongBan();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(RequestViewModels model, IEnumerable<HttpPostedFileBase> listFile)
        {
            try
            {
                if (Session["User"] == null)
                {
                    return RedirectToAction("Index", "UserLogin");
                }
                ViewBag.PhongBan = new PhongBanKhachHangModels().GetPhongBan();
                foreach (HttpPostedFileBase file in listFile)
                {
                    //if (file == null)
                    //    {
                    //        TempData["Status"] = "Tải lên thật bại, vui lòng kiểm tra lại file đã chọn!";
                    //        return View("Index");
                    //    }
                    //else
                    //    {
                        string path = Server.MapPath("~/Content/" + file.FileName);
                        if (System.IO.File.Exists(path))
                            System.IO.File.Delete(path);
                        file.SaveAs(path);
                 
                  //  }

                }
            }
            catch (Exception ex)
            {
                TempData["Status"] = "Thêm thất bại, vui lòng kiểm tra lại file đã chọn!";
               // return RedirectToAction("Index", "Login");

            }




            if (Session["User"] == null)
                return RedirectToAction("Index", "Login");
            if (ModelState.IsValid)
            {
                Request request = new Request
                {
                    PhongBan = model.PhongBan,
                    Subject = model.Subject,
                    Value = model.Value,
                    UserID = ((UserWeb)Session["User"]).ID
                };
                new RequestModel().InsertRequest(request);
                TempData["Success"] = "Đã gửi thành công!";
                return RedirectToAction("Index", "Request");
            }
            else
            {
                ModelState.AddModelError("", "Không hợp lệ");
            }
            return View(model);
        }

        public ActionResult RequestList(int id)
        {
            List<Request> list = rq.Request_SelectAll(id);
            List<RequestViewModels> itemView = new List<RequestViewModels>();
            foreach (Request rq in list)
            {
                RequestViewModels request = new RequestViewModels
                {
                    ID = rq.ID,
                    PhongBan = rq.PhongBan,
                    Subject = rq.Subject,
                    ThoiGian = rq.Time,
                    Value = rq.Value.Length > 64 ? rq.Value.Substring(0, 63) + "..." : rq.Value
            };
                itemView.Add(request);
            }
            return View(itemView);
        }

        public ActionResult ChuaXuLy(int? id)
        {
            List<Request> list = rq.Request_SelectAllStatus(id, false);
            List<RequestViewModels> itemView = new List<RequestViewModels>();
            foreach (Request rq in list)
            {
                RequestViewModels request = new RequestViewModels
                {
                    ID = rq.ID,
                    PhongBan = rq.PhongBan,
                    Subject = rq.Subject,
                    ThoiGian = rq.Time,
                    Value = rq.Value.Length > 64 ? rq.Value.Substring(0, 63) + "..." : rq.Value


                };
                itemView.Add(request);
            }
            return View(itemView);
        }
        public ActionResult DaXuLy(int? id)
        {
            List<Request> list = rq.Request_SelectAllStatus(id, true);
            List<RequestViewModels> itemView = new List<RequestViewModels>();
            foreach (Request rq in list)
            {
                RequestViewModels request = new RequestViewModels
                {
                    ID = rq.ID,
                    PhongBan = rq.PhongBan,
                    Subject = rq.Subject,
                    ThoiGian = rq.Time,
                    Value = rq.Value.Length > 64 ? rq.Value.Substring(0, 63) + "..." : rq.Value


                };
                itemView.Add(request);
            }
            return View(itemView);
        }

    }
}