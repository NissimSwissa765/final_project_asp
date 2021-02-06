#nullable disable

namespace Project1.Models
{
    public partial class EmployeeShift
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? ShiftId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Shift Shift { get; set; }
    }
}
