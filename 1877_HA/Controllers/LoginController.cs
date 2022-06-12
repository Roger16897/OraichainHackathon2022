using _1877_HA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1877_HA.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        ModelOrai db = new ModelOrai();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NotFound()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            Coding codeing = new Coding();
            string pass_hash = codeing.Encrypt(password + codeing.salt);
            var user = db.tb_User.Where(x => x.TenDangNhap == username && x.MatKhau == pass_hash).ToList();
            if (user.Count != 0)
            {

                if(user.FirstOrDefault().Type=="Quản trị")
                {
                    Session["type"] = "1";
                }
                else if (user.FirstOrDefault().Type == "Chuyên gia")
                {
                    Session["type"] = "2";
                }
                else if (user.FirstOrDefault().Type == "Nhà cung cấp AI")
                {
                    Session["type"] = "3";
                }
                else
                {
                    Session["type"] = "4";
                }
                Session["uid"] = user.FirstOrDefault().ID;
                Session["TenDangNhap"] = username;
                if(Session["type"].ToString()=="1")
                {
                    return Json(new
                    {
                        redirectUrl = Url.Action("Index", "Home", new { Area = "Admin" }),
                        status = true
                    });
                }
                else if (Session["type"].ToString() == "2")
                {
                    return Json(new
                    {
                        redirectUrl = Url.Action("Home", "QuanLyCG", new { Area = "Admin" }),
                        status = true
                    });
                }
                else if (Session["type"].ToString() == "3")
                {
                    return Json(new
                    {
                        redirectUrl = Url.Action("Home", "QuanLyNhaCCAI", new { Area = "Admin" }),
                        status = true
                    });
                }
                else
                {
                    return Json(new
                    {
                        redirectUrl = Url.Action("Index", "Home", new { Area = "Client" }),
                        status = true
                    });
                }
               
            }
            else
            {
                return Json(new
                {
                    redirectUrl = Url.Action("Index", "Login"),
                    status = false
                });
            }
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            Session["uid"] = null;
            return Redirect("~/Login/Index");
        }
    }

}