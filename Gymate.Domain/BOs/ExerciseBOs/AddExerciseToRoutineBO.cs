using Gymate.Domain.BOs.ExercisesBOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gymate.Domain.BOs.ExerciseBOs
{
    public class AddExerciseToRoutineBO
    {
        public int RoutineId { get; set; }

        public string RoutineName { get; set; }

        public int ExerciseId { get; set; }
        public ICollection<SingleExerciseBO> ExercisesForRoutine { get; set; }
    }
}
