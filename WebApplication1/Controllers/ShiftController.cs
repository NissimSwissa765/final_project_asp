using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.filter;

namespace WebApplication1.Controllers
{

    [CustomAuthFilter]
    public class ShiftController : BaseController
    {
     
        public ActionResult HomePage()
        {

            ViewBag.shiftsTable = ShiftSingleton.Instance.GetAll();
            ViewBag.shiftsByEmp= EmployeeShiftSingleton.Instance.GetAll("shiftID_");
            return View("HomePage");
               
          
        }
        public ActionResult AddPage()
        {
            return View("AddPage");
        }

        public ActionResult Add(DateTime date, int StartTime, int EndTime)
        {
            Guid g = Guid.NewGuid();
            var key = Guid.NewGuid().ToString();

            ShiftSingleton.Instance.Add(new Shift(key, date, StartTime, EndTime));

            return RedirectToAction("HomePage");
        }

    }
}