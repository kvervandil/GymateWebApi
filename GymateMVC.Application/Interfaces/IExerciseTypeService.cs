using GymateMVC.Application.ViewModels.ExerciseTypeVm;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymateMVC.Application.Interfaces
{
    public interface IExerciseTypeService
    {
        ListForExerciseTypeListVm GetAllExerciseTypes(int pageSize, int pageNo, string searchString);
        int AddExerciseType(NewExerciseTypeVm newExerciseType);
        NewExerciseTypeVm GetExerciseTypeForEdit(int id);
        void UpdateExerciseType(NewExerciseTypeVm model);
        void DeleteExerciseType(int id);
    }
}
