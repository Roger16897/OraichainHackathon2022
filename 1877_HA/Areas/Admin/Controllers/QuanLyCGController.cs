using _1877_HA.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1877_HA.Areas.Admin.Controllers
{
    [AuthorizeController]
    public class QuanLyCGController : BaseController
    {
        // GET: Admin/QuanLyCG
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult DanhSachYeuCau()
        {
            return View();
        }
        ////phan nay chua lam
        public ActionResult Vi()
        {
            return View();
        }
    }
}