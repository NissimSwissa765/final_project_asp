using System.Collections.Generic;

#nullable disable

namespace Project1.Models
{
    public partial class ShiftUtils
    {
        factoryDBContext db = new factoryDBContext();
        public List<Shift> GetShiftsList()
        {
            List<Shift> l = new List<Shift>();
            foreach (var item in db.Shifts)
            {
                l.Add(item);
            }
            return l;
        }
        public void AddNewShift(Shift newShift)
        {
            db.Shifts.Add(newShift);
            db.SaveChanges();
        }

    }
}
