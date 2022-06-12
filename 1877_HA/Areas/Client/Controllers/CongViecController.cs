using _1877_HA.Controllers;
using _1877_HA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1877_HA.Areas.Client.Controllers
{
    public class CongViecController : BaseController
    {
        // GET: Client/CongViec
        ModelOrai db = new ModelOrai();
        public ActionResult Index()
        {
            return View();
        }
    }
}