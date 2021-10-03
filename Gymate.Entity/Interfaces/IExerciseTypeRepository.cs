using Gymate.Infrastructure.Entity.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Gymate.Infrastructure.Entity.Interfaces
{
    public interface IExerciseTypeRepository
    {
        Task<int> AddExerciseType(ExerciseType exerciseType, CancellationToken cancellationToken);
        Task<bool> DeleteExerciseType(int id, CancellationToken cancellationToken);
        IQueryable<ExerciseType> GetAllExerciseTypes();
        Task<ExerciseType> GetExerciseTypeById(int id, CancellationToken cancellationToken);
        ExerciseType GetExerciseTypeByName(string name);
        Task<bool> UpdateExerciseType(ExerciseType exerciseType, CancellationToken cancellationToken);
        IQueryable<ExerciseType> GetExerciseTypesWithExercises();
        Task<List<ExerciseType>> GetExerciseTypes(int pageSize, int pageNo, string searchString, CancellationToken cancellationToken);
        Task<int> GetNoOfExerciseTypes(CancellationToken cancellationToken);
    }
}
