using System;
using System.Collections.Generic;
using System.Text;

namespace GymateMVC.Domain.Model
{
    public class DayOfWeek
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RoutineId { get; set; }
        public virtual Routine Routine { get; set; }
    }
}
