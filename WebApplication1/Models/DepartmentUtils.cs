using System.Collections.Generic;
using System.Linq;


#nullable disable

namespace Project1.Models
{
    class DepartmentUtils
    {
        factoryDBContext db = new factoryDBContext();

        public bool IsEmpty(int depID)
        {
            List<int> l = new List<int>();

            foreach (var item in db.Employees)
            {
                if (depID==item.DepId)
                {
                    l.Add(item.Id);
                }
            } 
            if (l.Count()==0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<DepWithMangName> GetDepartmentsList()
        {
            var t = from dep in db.Departments
                    join emp in db.Employees
                    on dep.Manager equals emp.Id
                    select new DepWithMangName
                    {
                        Id = dep.Id,
                        DepName = dep.DepName,
                        Manager = emp.FirstName+" "+emp.LastName,
                    };
            List<DepWithMangName> l = new List<DepWithMangName>{};
            foreach (DepWithMangName i in t)
            {
                l.Add(i);
            }
            return l;
        }

        public void AddNewDep(string DepName, int Manager)
        {
            db.Departments.Add(new Department{
                DepName=DepName,
                Manager=Manager
            });
            db.SaveChanges();
        }
        public void DeleteDepartment(int DepID)
        {
            var ToDel = db.Departments.Where(x => x.Id == DepID).First();
            db.Departments.Remove(ToDel);
            db.SaveChanges();
        }
        public Department GetDepartment(int DepID)
        {
            return db.Departments.Where(x => x.Id ==DepID).First();
        }
        public void Update(Department dep, int Manager)
        {
            Department toUpdate = db.Departments.Where(x=>x.Id==dep.Id).First();
            toUpdate.DepName = dep.DepName;
            toUpdate.Manager = Manager;
            db.SaveChanges();
        }
    }

}
