using Gymate.Domain.BOs.ExerciseBOs;
using Gymate.Domain.BOs.ExercisesBOs;
using Gymate.Domain.BOs.General;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Gymate.Application.Interfaces
{
    public interface IExerciseService
    {
        Task<PagedResultBO<AllExercisesBO>> GetAllExercises(int pageSize, int pageNo, string searchString,
                                                                CancellationToken cancellationToken);
        Task<int?> AddExercise(NewExerciseBO newExerciseBO, CancellationToken cancellationToken);
        Task<SingleExerciseBO> GetExercise(int id, CancellationToken cancellationToken);
        Task<EditExerciseBO> GetExerciseForEdit(int id, CancellationToken cancellationToken);
        Task<bool> UpdateExercise(int id, EditExerciseBO model, CancellationToken cancellationToken);
        Task<bool> DeleteExercise(int id, CancellationToken cancellationToken);
    }
}
