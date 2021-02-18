using GymateMVC.Application.ViewModels.ExerciseTypeVm;
using GymateMVC.Application.ViewModels.ExerciseVm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymateMVC.Application.Interfaces
{
    public interface IExerciseService
    {
        ListForExercisesListVm GetAllExercises();
        int AddExercise(NewExerciseVm newExerciseVm, ExerciseTypeForListVm exerciseTypeForListVm);
        ExerciseForListVm GetExercise(int id);
    }
}
