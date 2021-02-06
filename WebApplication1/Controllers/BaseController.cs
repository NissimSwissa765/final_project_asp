using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            var model = filterContext.Controller.ViewData;

            if (HttpContext.Session["User"] != null)

            {

                model["UserName"] = HttpContext.Session["User"];
            }
           
           

        }

       
    }
}