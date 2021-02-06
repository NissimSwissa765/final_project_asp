using System.Collections.Generic;
using System;

namespace Project1.Models
{
    public  class EmployeeSingleton
    {
        Dictionary<string, Employee> departments;





        private static volatile EmployeeSingleton instance;
        private static object syncRoot = new Object();

        private EmployeeSingleton()
        {
            Guid g = Guid.NewGuid();
            this.departments = new Dictionary<string, Employee>();
            var key = Guid.NewGuid().ToString();
            this.departments.Add(key, new Employee(key, "FirstName ", "LastName", 2020));
             key = Guid.NewGuid().ToString();
            this.departments.Add(key, new Employee(key, "FirstName 1 ", "LastName 1", 2020));
             key = Guid.NewGuid().ToString();
            this.departments.Add(key, new Employee(key, "FirstName 2 ", "LastName 2", 2020));
             key = Guid.NewGuid().ToString();
            this.departments.Add(key, new Employee(key, "FirstName 3 ", "LastName 3", 2020));
             key = Guid.NewGuid().ToString();
            this.departments.Add(key, new Employee(key, "FirstName 4 ", "LastName 4", 2020));


        }

        public static EmployeeSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new EmployeeSingleton();
                    }
                }

                return instance;
            }
        }


        public List<Employee> GetAll()
        {

            List<Employee> retval = new List<Employee>();

            foreach (var item in departments)
            {
                retval.Add(item.Value);

            }

            return retval;

        }
        public Employee Get(string id)
        {
            return departments[id];


        }
       
        public void Add(Employee department)
        {
            departments.Add(department.Id, department);


        }
        public void Delete(string department)
        {
            departments.Remove(department);


        }
        public void Update(Employee department)
        {
            departments[department.Id] = department;


        }


       

             public List<Employee> Search(string text)
        {

            List<Employee> retval = new List<Employee>();

            foreach (var item in departments)
            {
                if (item.Value.FirstName.Contains( text))
                {
                    retval.Add(item.Value);
                    continue;

                }
                if (item.Value.LastName.Contains(text))
                {
                    retval.Add(item.Value);
                    continue;

                }
                if (item.Value.DepId!=null&&item.Value.DepId.Contains(text))
                {
                    retval.Add(item.Value);
                    continue;

                }



            }

            return retval;

        }
    }
}
