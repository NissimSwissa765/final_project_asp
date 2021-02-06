using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.filter;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{

    [CustomAuthFilter]
    public class DepartmentController : BaseController
    {
        
        public ActionResult HomePage()
        {


            ViewBag.depTable = DepartmentSingleton.Instance.GetAll();


           return View("HomePage");
             

           
        }
        public ActionResult AddPage()
        {
            ViewBag.List = EmployeeSingleton.Instance.GetAll();

            return View("AddPage");
            

        }

        [HttpPost]
        public ActionResult Add(string DepName, string Manager)
        {
            Guid g = Guid.NewGuid();
            var key = Guid.NewGuid().ToString();

            DepartmentSingleton.Instance.Add(new Department(key, DepName, Manager));

            return RedirectToAction("HomePage", "Department");
        }

        public ActionResult Delete(string DepID)
        {
            DepartmentSingleton.Instance.Delete(DepID);

            return RedirectToAction("HomePage", "Department");
        }

        public ActionResult EditPage(string DepID)
        {


          var item=  DepartmentSingleton.Instance.Get(DepID);

            ViewBag.List = EmployeeSingleton.Instance.GetAll();
             return View("EditPage", item);
                
           
        }

        public ActionResult UpdateDep(string Id , string DepName, string Manager)
        {
            DepartmentSingleton.Instance.Update(new Department(Id, DepName, Manager));

            return RedirectToAction("HomePage", "Department");
        }
    }

}