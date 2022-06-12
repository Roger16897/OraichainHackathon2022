using _1877_HA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace _1877_HA.Controllers
{
    public class AuthorizeController : System.Web.Mvc.ActionFilterAttribute
    {
        // GET: Authorize
        ModelOrai db = new ModelOrai();
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                int userID = int.Parse(HttpContext.Current.Session["uid"].ToString());
                var admin = db.tb_User.Find(userID);
                if (admin.isAdmin == true)
                {
                    return;
                }
                var listpermission = from p in db.tb_PhanQuyen
                                     join g in db.tb_Action on p.Id_Action equals g.ID
                                     where p.Id_NguoiDung == userID
                                     select g.ActionName;
                string actionName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + "Controller-" + filterContext.ActionDescriptor.ActionName;
                if (!listpermission.Contains(actionName))
                {
                    filterContext.Result = new RedirectResult("~/Login/NotFound");
                    return;
                }
            }
            catch
            {
                filterContext.Result = new RedirectResult("~/Login/NotFound");
                return;
            }

        }
    }

    public class AuthorizeApiController : System.Web.Http.Filters.ActionFilterAttribute
    {
        ModelOrai db = new ModelOrai();
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext filterContext)
        {
            int userID = int.Parse(HttpContext.Current.Session["uid"].ToString());
            var admin = db.tb_User.Find(userID);
            if (admin.isAdmin == true)
            {
                return;
            }
            //var listpermission = db.bot_permission.Where(i => i.id_user == userID);
            var listpermission = from p in db.tb_PhanQuyen
                                 join g in db.tb_Action on p.Id_Action equals g.ID
                                 where p.Id_NguoiDung == userID
                                 select g.ActionName;
            string actionName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + "Controller-" + filterContext.ActionDescriptor.ActionName;
            if (!listpermission.Contains(actionName) && !filterContext.ActionDescriptor.ActionName.Equals("Get"))
            {
                var response = filterContext.Request.CreateResponse(HttpStatusCode.Redirect);
                string fullyQualifiedUrl = filterContext.Request.RequestUri.GetLeftPart(UriPartial.Authority) + "/Login/NotFound";
                response.Headers.Location = new Uri(fullyQualifiedUrl);
                filterContext.Response = response;
                return;
            }
        }
    }
}