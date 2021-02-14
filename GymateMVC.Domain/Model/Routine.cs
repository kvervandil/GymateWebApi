using System;
using System.Collections.Generic;
using System.Text;

namespace GymateMVC.Domain.Model
{
    public class Routine
    {
        public int Id { get; set; }
        public int DayOfWeekId { get; set; }
        public virtual string DayOfWeek { get; set; }
        public virtual ICollection<ExerciseRoutine> ExerciseRoutines { get; set; }
    }
}
