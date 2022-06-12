using _1877_HA.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1877_HA.Areas.Admin.Controllers
{
    [AuthorizeController]
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}