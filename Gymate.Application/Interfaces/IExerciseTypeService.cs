using Gymate.Application.ViewModels.ExerciseTypeVm;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Gymate.Application.Interfaces
{
    public interface IExerciseTypeService
    {
        ListForExerciseTypeListVm GetAllExerciseTypes(int pageSize, int pageNo, string searchString);
        int AddExerciseType(NewExerciseTypeVm newExerciseType);
        NewExerciseTypeVm GetExerciseTypeForEdit(int id);
        void UpdateExerciseType(NewExerciseTypeVm model);
        void DeleteExerciseType(int id);
        List<SelectListItem> GetSelectListOfAllExerciseTypes(int chosenExerciseTypeId = 0);
        ListOfExerciseTypesWithExercisesForRoutine GetAllExerciseTypesWithExercises();
    }
}
