using Project1.Models;
using System;
using System.Collections.Generic;


namespace WebApplication1.Model
{
    public class DepartmentSingleton
    {



        Dictionary<string, Department> departments ;





        private static volatile DepartmentSingleton instance;
        private static object syncRoot = new Object();

        private DepartmentSingleton() {
            departments = new Dictionary<string, Department>();
         
        }

        public static DepartmentSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new DepartmentSingleton();
                    }
                }

                return instance;
            }
        }


        public  List<Department> GetAll()
        {
         
            List<Department> retval = new List<Department>();
           
            foreach (var item in departments)
            {
                retval.Add(item.Value);
               
            }

            return retval;

        }
        public  Department Get(string id)
        {
            return departments[id];
            

        }
        public void Add(Department department)
        {
            departments.Add(department.Id, department);


        }
        public void Delete(string department)
        {
            departments.Remove(department);


        }
        public void Update(Department department)
        {
            departments[department.Id]= department;


        }
    }
}