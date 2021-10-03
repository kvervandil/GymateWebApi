using System.Collections.Generic;

namespace Gymate.Application.ViewModels.ExerciseTypeVm
{
    public class ListOfExerciseTypesWithExercisesForRoutine
    {
        public List<ExerciseTypeWithExercisesForRoutineVm> ListExerciseTypesForRoutine { get; set; }

        public int Count { get; set; }
    }
}
