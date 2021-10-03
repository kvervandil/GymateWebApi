using Gymate.Infrastructure.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Gymate.Infrastructure.Interfaces
{
    public interface IExerciseRepository
    {
        Task<bool> DeleteExercise(int exerciseId, CancellationToken cancellationToken);

        Task<int> AddExercise(Exercise exercise, CancellationToken cancellationToken);
        Task<Exercise> GetExerciseById(int id, CancellationToken cancellationToken);
        IQueryable<Exercise> GetExercisesByTypeId(int exerciseTypeId);
        Task<List<Exercise>> GetExercisesByRoutineId(int routineId, CancellationToken cancellationTokens);
        Task<List<Exercise>> GetAllExercises(int pageSize, int pageNo, string searchString,
            CancellationToken cancellationToken);
        Task<bool> UpdateExercise(Exercise exercise, CancellationToken cancellationToken);
        Task<bool> UpdateExerciseWithExerciseRoutine(Exercise exercise, ExerciseRoutine exerciseRoutine, CancellationToken cancellationToken);
        Task<int> GetNoOfExercises(CancellationToken cancellationToken);
    }
}
