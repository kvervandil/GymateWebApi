using System.Collections.Generic;

namespace Gymate.Infrastructure.Model
{
    public class Routine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ExerciseRoutine> ExerciseRoutines { get; set; }
    }
}
