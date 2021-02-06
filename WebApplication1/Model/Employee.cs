using System.Collections.Generic;


namespace Project1.Models
{
    public class Employee
    {
       

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int YearStarted { get; set; }
        public string DepId { get; set; }

        public string Dep { get; set; }
   
        public  ICollection<string> EmployeeShifts { get; set; }

        public Employee(string Id, string FirstName, string LastName, int YearStarted)
        {

            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.YearStarted = YearStarted;

            EmployeeShifts = new HashSet<string>();
        }
    }
}
