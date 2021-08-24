using Gymate.Infrastructure.Entity.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Gymate.Infrastructure.Entity.Interfaces
{
    public interface IExerciseRepository
    {
        Task<bool> DeleteExercise(int id, CancellationToken cancellationToken);

        Task<int> AddExercise(Exercise exercise, CancellationToken cancellationToken);
        Task<Exercise> GetExerciseById(int id, CancellationToken cancellationToken);
        IQueryable<Exercise> GetExercisesByTypeId(int exerciseTypeId);
        IQueryable<Exercise> GetExercisesByRoutineId(int routineId);
        Task<List<Exercise>> GetAllExercises(int pageSize, int pageNo, string searchString,
            CancellationToken cancellationToken);
        Task<bool> UpdateExercise(Exercise exercise, CancellationToken cancellationToken);
        void UpdateExerciseWithExerciseRoutine(Exercise exercise, ExerciseRoutine exerciseRoutine);
        Task<int> GetNoOfExercises(CancellationToken cancellationToken);
    }
}
