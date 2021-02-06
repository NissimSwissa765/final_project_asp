using System.Collections.Generic;

#nullable disable

namespace Project1.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Departments = new HashSet<Department>();
            EmployeeShifts = new HashSet<EmployeeShift>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int YearStarted { get; set; }
        public int DepId { get; set; }

        public virtual Department Dep { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<EmployeeShift> EmployeeShifts { get; set; }
    }
}
