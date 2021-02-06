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
    public class EmployeeController : BaseController
    {

       
        public EmployeeController()
        {




        }

        public ActionResult HomePage()
        {
            ViewBag.empTable = EmployeeSingleton.Instance.GetAll();

            ViewBag.depList = DepartmentSingleton.Instance.GetAll();
            ViewBag.esList = EmployeeShiftSingleton.Instance.GetAll("shiftID_");


            return View("HomePage");
        }
        

        public ActionResult EditPage(string empID)
        {
            var item=  EmployeeSingleton.Instance.Get(empID);
            ViewBag.depList = DepartmentSingleton.Instance.GetAll();
            return View("EditPage", item);

        }

        public ActionResult UpdateEmp(string Id, string FirstName, string LastName, int YearStarted,string DepID)
        {
          var e=   EmployeeSingleton.Instance.Get(Id);
            e.FirstName = FirstName;
            e.LastName = LastName;
            e.YearStarted = YearStarted;
            e.DepId = DepID;
            EmployeeSingleton.Instance.Update(e);
            return RedirectToAction("HomePage", "Employee");
        }
        public ActionResult Delete(string empID)
        {
            EmployeeSingleton.Instance.Delete(empID);

            return RedirectToAction("HomePage", "Employee");
        }

        public ActionResult AddShiftPage(string empID)
        {


            var e = EmployeeSingleton.Instance.Get(empID);
            ViewBag.EmpName = e.FirstName + " " + e.LastName;

           
            ViewBag.empID = empID;
            ViewBag.shiftsList = ShiftSingleton.Instance.GetAll();
            return View("AddShiftPage");
        }
        [HttpPost]
        public ActionResult UpdateShifts(string empID, string shiftID)
        {
            EmployeeShiftSingleton.Instance.Add("empID_" + empID, new EmployeeShift(empID, shiftID));
            EmployeeShiftSingleton.Instance.Add("shiftID_" + shiftID, new EmployeeShift(empID, shiftID));


            return RedirectToAction("HomePage", "Employee");
        }
        [HttpPost]
        public ActionResult Search(string text)
        {
            List<int> lempID = new List<int>();


            ViewBag.empTable = EmployeeSingleton.Instance.Search(text);

            ViewBag.depList = DepartmentSingleton.Instance.GetAll();
            ViewBag.esList = EmployeeShiftSingleton.Instance.GetAll("shiftID_");
            return View("HomePage");

        }

    }
}