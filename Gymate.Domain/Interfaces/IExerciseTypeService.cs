using Gymate.Domain.BOs.ExerciseTypeBOs;
using Gymate.Domain.BOs.General;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Gymate.Application.Interfaces
{
    public interface IExerciseTypeService
    {
        Task<PagedResultBO<SingleExerciseTypeBO>> GetAllExerciseTypes(int pageSize, int pageNo, string searchString, CancellationToken cancellationToken);
        Task<int?> AddExerciseType(CreateExerciseTypeBO newExerciseType, CancellationToken cancellationToken);
        EditExerciseTypeBO GetExerciseTypeForEdit(int id, CancellationToken cancellationToken);
        Task<bool> UpdateExerciseType(int id, EditExerciseTypeBO model, CancellationToken cancellationToken);
        void DeleteExerciseType(int id, CancellationToken cancellationToken);
    }
}
