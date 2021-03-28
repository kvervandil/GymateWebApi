using System;
using System.Collections.Generic;
using System.Text;

namespace GymateMVC.Domain.Model
{
    public class Routine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ExerciseRoutine> ExerciseRoutines { get; set; }
    }
}
