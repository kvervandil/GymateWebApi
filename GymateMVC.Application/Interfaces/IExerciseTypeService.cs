using GymateMVC.Application.ViewModels.ExerciseTypeVm;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymateMVC.Application.Interfaces
{
    public interface IExerciseTypeService
    {
        ListForExerciseTypeListVm GetAllExerciseTypes();
        int AddExerciseType(NewExerciseTypeVm newExerciseType);
        ExerciseTypeForListVm GetExerciseType(int id);
    }
}
