using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class LoginController : BaseController
    {
       

        [HttpPost]
        public ActionResult VerifyLogin(string user, string pwd)
        {

            var userS = UserSingleton.Instance.GetByUserAndPassWord(user, pwd);
            if (userS==null)
            {
                
                 return RedirectToAction("Index", "Home", new { msg = "login failed" });
                   
                
            }
            HttpContext.Session.Add("User", userS.UserName);

            return RedirectToAction("HomePage", "Home");


        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}