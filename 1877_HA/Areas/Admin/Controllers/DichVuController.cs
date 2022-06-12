using _1877_HA.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1877_HA.Areas.Admin.Controllers
{
    [AuthorizeController]
    public class DichVuController : BaseController
    {
        // GET: Admin/DichVu
        public ActionResult DanhSachDichVu()
        {
            return View();
        }
        public ActionResult CauHinhThamSo()
        {
            return View();
        }
    }
}