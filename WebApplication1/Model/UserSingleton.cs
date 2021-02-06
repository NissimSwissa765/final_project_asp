using System.Collections.Generic;
using System;

namespace Project1.Models
{
    public  class UserSingleton
    {
        Dictionary<string, User> departments;





        private static volatile UserSingleton instance;
        private static object syncRoot = new Object();

        private UserSingleton()
        {
            departments = new Dictionary<string, User>();
            var key = Guid.NewGuid().ToString();

            departments.Add(key, new User(key, "nissim", "nissim", "654321",10));

        }

        public static UserSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new UserSingleton();
                    }
                }

                return instance;
            }
        }


        public List<User> GetAll()
        {

            List<User> retval = new List<User>();

            foreach (var item in departments)
            {
                retval.Add(item.Value);

            }

            return retval;

        }
        public User Get(string id)
        {
            return departments[id];


        }
        public User GetByUserAndPassWord(string user, string pass)
        {
            foreach (var item in departments)
            {
                if (item.Value.UserName== user && item.Value.Pwd == pass)
                {
                    return item.Value;
                }
               

            }

            return null;


        }
    }
}
