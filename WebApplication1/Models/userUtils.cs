using System;
using System.Linq;


#nullable disable

namespace Project1.Models
{
    class userUtils
    {
        factoryDBContext db = new factoryDBContext();
        public int limit = 120;
        public bool VerifyLogin(string user, string pwd)
        {
            foreach (var u in db.Users)
            {
                if(u.UserName==user && u.Pwd==pwd)
                {
                    return true;
                }              
            }
            return false;
        }

        public string GetUserFullName(string user)
        {
            return db.Users.Where(u => u.UserName==user).First().FullName;
        }

        public int GetActionsCounter(string user)
        {
            var c = db.Users.Where(u => u.UserName==user).First().ActionsCounter;
            if(c<=limit)
            {
                return c;
            }
            else
            {
                return -1;
            }
        }

        public void SaveLastAction(string user, int current)
        {
            var toSave = db.Users.Where(u => u.UserName==user).First();
            toSave.LastActionDay = current;
            db.SaveChanges();
        }

        public int PullLastActionDay(string user)
        {
            return db.Users.Where(u => u.UserName==user).First().LastActionDay;
        }

        public bool CheckResetRule(string user)
        {
            int now = DateTime.UtcNow.DayOfYear;
            return PullLastActionDay(user) != now;
        }

        public void CounterReset(string user)
        {
            var toReset = db.Users.Where(u => u.UserName==user).First();
            toReset.ActionsCounter = 0;
            db.SaveChanges();
        }

        public void UpActionsCounter(string user)
        {
            var toUp = db.Users.Where(u => u.UserName==user).First();
            toUp.ActionsCounter +=1;
            db.SaveChanges();
        }

        public void ActionsUpdate(string user)
        {   
            int now = DateTime.UtcNow.DayOfYear;
            
            if(CheckResetRule(user))
            {
                CounterReset(user);
                SaveLastAction(user, now);            
            }
            else
            {
                UpActionsCounter(user);   
            }
        }

    }

}
