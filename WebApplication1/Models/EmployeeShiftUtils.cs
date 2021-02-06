using System.Collections.Generic;
using System.Linq;


#nullable disable

namespace Project1.Models
{
    public partial class EmployeeShiftUtils
    {
        factoryDBContext db = new factoryDBContext();
        public List<EmployeeShift> GetESListByID(int empID)
        {
            List<EmployeeShift> l = new List<EmployeeShift>();
            foreach (var item in db.EmployeeShifts)
            {
                if (item.EmployeeId==empID)
                {
                    l.Add(item);    
                }
            }
            return l;
        }
        public List<EmployeeShift> GetESList()
        {
            List<EmployeeShift> l = new List<EmployeeShift>();
            foreach (var item in db.EmployeeShifts)
            {
                l.Add(item);    
            }
            return l;
        }

        public void AddES(int empID, int shiftID)
        {
            db.EmployeeShifts.Add(new EmployeeShift{EmployeeId=empID, ShiftId=shiftID});
            db.SaveChanges();
        }

        public List<ShiftsByEmployee> EmpShiftsLists()
        {
            var sbe = from emp in db.Employees join es in db.EmployeeShifts on emp.Id equals es.EmployeeId
                        join shift in db.Shifts on es.ShiftId equals shift.Id
                        select new ShiftsByEmployee
                        {
                            EmployeeID = emp.Id,
                            FullName = emp.FirstName + " " + emp.LastName,
                            ShiftID = shift.Id,
                            Shifts = $"{shift.ShiftDate} {shift.StartTime}:00-{shift.EndTime}:00"
                        };
            List<ShiftsByEmployee> l = new List<ShiftsByEmployee>();            
            foreach(var item in sbe)
            {
                l.Add(item);
            }
            return l;
        }

    }
    
}
