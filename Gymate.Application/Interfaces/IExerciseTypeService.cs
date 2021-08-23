using Gymate.Application.ViewModels.ExerciseTypeVm;
using Gymate.Application.ViewModels.General;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Gymate.Application.Interfaces
{
    public interface IExerciseTypeService
    {
        Task<PagedResultDto<ExerciseTypeForListVm>> GetAllExerciseTypes(int pageSize, int pageNo, string searchString, CancellationToken cancellationToken);
        int AddExerciseType(NewExerciseTypeVm newExerciseType);
        NewExerciseTypeVm GetExerciseTypeForEdit(int id);
        void UpdateExerciseType(NewExerciseTypeVm model);
        void DeleteExerciseType(int id);
        List<SelectListItem> GetSelectListOfAllExerciseTypes(int chosenExerciseTypeId = 0);
        ListOfExerciseTypesWithExercisesForRoutine GetAllExerciseTypesWithExercises();
    }
}
