
namespace Project1.Models
{
    public  class User
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Pwd { get; set; }
        public int ActionsCounter { get; set; }
     


        public User(string Id, string FullName, string UserName, string Pwd, int ActionsCounter)
        {
            this.Id = Id;
            this.FullName = FullName;
            this.UserName = UserName;
            this.Pwd = Pwd;
            this.ActionsCounter = ActionsCounter;
        }
    }
}
