using System.Collections.Generic;
using System;

namespace Project1.Models
{
    public  class ShiftSingleton
    {
        Dictionary<string, Shift> departments;





        private static volatile ShiftSingleton instance;
        private static object syncRoot = new Object();

        private ShiftSingleton()
        {
            departments = new Dictionary<string, Shift>();
         

        }

        public static ShiftSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ShiftSingleton();
                    }
                }

                return instance;
            }
        }


        public List<Shift> GetAll()
        {

            List<Shift> retval = new List<Shift>();

            foreach (var item in departments)
            {
                retval.Add(item.Value);

            }

            return retval;

        }
        public Shift Get(string id)
        {
            return departments[id];


        }
        public void Add(Shift department)
        {
            departments.Add(department.Id, department);


        }
    }
}
