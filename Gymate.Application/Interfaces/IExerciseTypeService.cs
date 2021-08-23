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
        Task<int?> AddExerciseType(NewExerciseTypeVm newExerciseType, CancellationToken cancellationToken);
        NewExerciseTypeVm GetExerciseTypeForEdit(int id);
        Task<bool> UpdateExerciseType(int id, UpdateExerciseTypeVm model, CancellationToken cancellationToken);
        void DeleteExerciseType(int id);
        List<SelectListItem> GetSelectListOfAllExerciseTypes(int chosenExerciseTypeId = 0);
        ListOfExerciseTypesWithExercisesForRoutine GetAllExerciseTypesWithExercises();
    }
}
