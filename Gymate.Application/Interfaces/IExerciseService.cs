using Gymate.Application.ViewModels.ExerciseVm;
using Gymate.Application.ViewModels.General;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Gymate.Application.Interfaces
{
    public interface IExerciseService
    {
        Task<PagedResultDto<ExerciseForListVm>> GetAllExercises(int pageSize, int pageNo, string searchString,
                                                                CancellationToken cancellationToken);
        Task<int?> AddExercise(NewExerciseVm newExerciseVm, CancellationToken cancellationToken);
        Task<ExerciseForListVm> GetExercise(int id, CancellationToken cancellationToken);
        Task<NewExerciseVm> GetExerciseForEdit(int id, CancellationToken cancellationToken);
        Task<bool> UpdateExercise(int id, NewExerciseVm model, CancellationToken cancellationToken);
        Task<bool> DeleteExercise(int id, CancellationToken cancellationToken);
        Task<List<SelectListItem>> GetSelectListOfAllExercises(int chosenExerciseId = 0);
    }
}
