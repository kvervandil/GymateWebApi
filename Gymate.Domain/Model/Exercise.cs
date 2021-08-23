using System.Collections.Generic;

namespace Gymate.Infrastructure.Entity.Model
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ExerciseTypeId { get; set; }
        public virtual ExerciseType ExerciseType { get; set; }
        public ICollection<ExerciseRoutine> ExerciseRoutines { get; set; }
        public ICollection<LoadForExercise> Load { get; set; }
    }
}
