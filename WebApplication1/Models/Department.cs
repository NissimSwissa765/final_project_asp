using System.Collections.Generic;

#nullable disable

namespace Project1.Models
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string DepName { get; set; }
        public int? Manager { get; set; }

        public virtual Employee ManagerNavigation { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
