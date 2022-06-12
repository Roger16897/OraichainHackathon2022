using _1877_HA.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1877_HA.Areas.Admin.Controllers
{
    [AuthorizeController]
    public class NhaCungCapAIController : BaseController
    {
        // GET: Admin/NhaCungCapAI
        public ActionResult Index()
        {
            return View();
        }
    }
}