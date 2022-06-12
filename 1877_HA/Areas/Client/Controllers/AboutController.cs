using _1877_HA.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1877_HA.Areas.Client.Controllers
{
    public class AboutController : BaseController
    {
        // GET: Client/About
        public ActionResult Index()
        {
            return View();
        }
    }
}