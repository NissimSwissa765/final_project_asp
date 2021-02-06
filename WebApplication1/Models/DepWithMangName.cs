#nullable disable

namespace Project1.Models
{
    public partial class DepWithMangName
    {

        public int Id { get; set; }
        public string DepName { get; set; }
        public string Manager { get; set; }
        public bool IsEmpty { get; set; }
    }
}
