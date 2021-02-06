using System.Collections.Generic;
using System;

namespace Project1.Models
{
    public  class EmployeeShiftSingleton
    {
        Dictionary<string, EmployeeShift> departments;





        private static volatile EmployeeShiftSingleton instance;
        private static object syncRoot = new Object();

        private EmployeeShiftSingleton()
        {
            departments = new Dictionary<string, EmployeeShift>();
       

        }

        public static EmployeeShiftSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new EmployeeShiftSingleton();
                    }
                }

                return instance;
            }
        }


        public List<EmployeeShift> GetAll(string prefix)
        {

            List<EmployeeShift> retval = new List<EmployeeShift>();

            foreach (var item in departments)
            {
                if (item.Key.Contains(prefix)) {
                    retval.Add(item.Value);
                }
            }

            return retval;

        }
        public List<EmployeeShift> Get(string id)
        {
            List<EmployeeShift> retval = new List<EmployeeShift>();

            foreach (var item in departments)
            {
                retval.Add(item.Value);

            }

            return retval;


        }


        public void Add(string key,EmployeeShift department)
        {
            //check if contains
            departments.Add(key, department);


        }



       
    }
}
