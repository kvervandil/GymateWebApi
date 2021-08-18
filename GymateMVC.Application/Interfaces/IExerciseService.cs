using Gymate.Application.ViewModels.ExerciseVm;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Gymate.Application.Interfaces
{
    public interface IExerciseService
    {
        ListForExerciseListVm GetAllExercises(int pageSize, int pageNo, string searchString);
        int AddExercise(NewExerciseVm newExerciseVm);
        ExerciseForListVm GetExercise(int id);
        NewExerciseVm GetExerciseForEdit(int id);
        void UpdateExercise(NewExerciseVm model);
        void DeleteExercise(int id);
        List<SelectListItem> GetSelectListOfAllExercises(int chosenExerciseId = 0);
    }
}
