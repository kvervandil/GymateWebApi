using Gymate.Domain.BOs.ExerciseBOs;
using System.Collections.Generic;

namespace Gymate.Domain.BOs.ExerciseTypeBOs
{
    public class ExerciseTypeWithExerciseForRoutineBO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ExerciseForRoutineBO> Exercises { get; set; }
    }
}
