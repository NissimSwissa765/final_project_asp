using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.filter;

namespace WebApplication1.Controllers
{
    
    public class HomeController : BaseController
    {

        public HomeController()
        {
           
        }

        public ActionResult Index(string msg)
        {
            ViewBag.msg = msg;
            return View();
        }

        public ActionResult Privacy()
        {
            return View();
        }

        [CustomAuthFilter]
        public ActionResult HomePage()
        {
            ViewBag.UserName = "";
            return View("Homepage");

            

        }


       

    }
}