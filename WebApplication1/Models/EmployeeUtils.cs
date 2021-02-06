using System.Collections.Generic;
using System.Linq;


#nullable disable

namespace Project1.Models
{
    public partial class EmployeeUtils
    {
        factoryDBContext db = new factoryDBContext();
        public List<Employee> GetEmployeesList()
        {
            List<Employee> l = new List<Employee>();
            foreach (var item in db.Employees)
            {
                l.Add(item);
            }
            return l;
        }
        public Employee GetEmployee(int empID)
        {
            return db.Employees.Where(x => x.Id ==empID).First();
        }
    
        public void Update(Employee emp, int DepID)
        {
            Employee toUpdate = db.Employees.Where(x=>x.Id==emp.Id).First();
            toUpdate.FirstName = emp.FirstName;
            toUpdate.LastName = emp.LastName;
            toUpdate.YearStarted = emp.YearStarted;
            toUpdate.DepId = DepID;
            db.SaveChanges();
        }
        public void DeleteEmployee(int empID)
        {
            var shiftsToDel = db.EmployeeShifts.Where(x=>x.EmployeeId==empID).ToList();
            if (shiftsToDel.Count()>0)
            {
                foreach (var item in shiftsToDel)
                {
                    db.EmployeeShifts.Remove(item);
                }    
            }
            
            var empToDel = db.Employees.Where(x => x.Id == empID).First();
            db.Employees.Remove(empToDel);
            db.SaveChanges();
        }
    }
    
}
