
using System.Collections.Generic;

namespace Project1.Models
{
    public  class EmployeeShift
    {

        public string EmployeeID;


        public  string ShiftIds;




       
      
        public EmployeeShift(string EmployeeId, string ShiftIds)
        {

            this.EmployeeID = EmployeeId;
            this.ShiftIds = ShiftIds;

        }

        public string Shifts()
        {
            var s = ShiftSingleton.Instance.Get(ShiftIds);
            return s.ShiftDate + ":"+s.StartTime + "-"+ s.StartTime;
        }
        public string FullName()
        {
            var s = EmployeeSingleton.Instance.Get(EmployeeID);
            return s.FirstName + " " + s.LastName + "-";
        }
      

    }
}
