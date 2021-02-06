using System.Collections.Generic;


namespace Project1.Models
{
    public class Department
    {


        public string Id { get; set; }
        public string DepName { get; set; }
        public string Manager { get; set; }

        public virtual ICollection<int> Employees { get; set; }
        public bool IsEmpty()
        {
            if (Employees == null || Employees.Count == 0)
            {
                return true;
            }

            return false;
        }
        public Department(string Id, string DepName, string Manager)
        {
            this.Id = Id;
            this.DepName = DepName;
            this.Manager = Manager;
            Employees = new HashSet<int>();
        }
    }
}
