using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Gymate.Infrastructure.Interfaces
{
    public interface IRoutineRepository
    {
        Task<Routine> GetRoutineById(int id, CancellationToken cancellationToken);

        Task<int> AddRoutine(Routine routine, CancellationToken cancellationToken);

        Task<bool> DeleteRoutine(int id, CancellationToken cancellationToken);

        Task<List<Routine>> GetAllRoutines(CancellationToken cancellationToken);
        Task<bool> UpdateRoutineWithName(Routine routine, CancellationToken cancellationToken);
        Task<bool> UpdateRoutineWithExercise(int routineId, ExerciseRoutine exerciseRoutine, CancellationToken cancellationToken);
    }
}
