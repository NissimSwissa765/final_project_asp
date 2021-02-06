#nullable disable

namespace Project1.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Pwd { get; set; }
        public int ActionsCounter { get; set; }
        public int LastActionDay { get; set; }
    }
}
