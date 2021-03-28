using System;
using System.Collections.Generic;
using System.Text;

namespace GymateMVC.Application.ViewModels.ExerciseTypeVm
{
    public class ListOfExerciseTypesWithExercisesForRoutine
    {
        public List<ExerciseTypeWithExercisesForRoutineVm> ListExerciseTypesForRoutine { get; set; }

        public int Count { get; set; }
    }
}
