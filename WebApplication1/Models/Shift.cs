using System;
using System.Collections.Generic;

#nullable disable

namespace Project1.Models
{
    public partial class Shift
    {
        public Shift()
        {
            EmployeeShifts = new HashSet<EmployeeShift>();
        }

        public int Id { get; set; }
        public DateTime? ShiftDate { get; set; }
        public int? StartTime { get; set; }
        public int? EndTime { get; set; }

        public virtual ICollection<EmployeeShift> EmployeeShifts { get; set; }
    }
}
