using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1877_HA.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["uid"] == null)
            {
                filterContext.Result = RedirectToRoute("Default", new { controller = "", action = "" });
                //filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { Controller = "Login", action = "Index" }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}