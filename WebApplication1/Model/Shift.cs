using System;
using System.Collections.Generic;



namespace Project1.Models
{
    public  class Shift
    {
      

        public string Id { get; set; }
        public DateTime ShiftDate { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }

        public Shift(string Id, DateTime ShiftDate, int StartTime, int EndTime)
        {
            this.Id = Id;
            this.ShiftDate = ShiftDate;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
        }
    }
}
