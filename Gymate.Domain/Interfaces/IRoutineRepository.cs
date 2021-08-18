using Gymate.Domain.Model;
using System.Linq;

namespace Gymate.Domain.Interfaces
{
    public interface IRoutineRepository
    {
        Routine GetRoutineById(int id);

        int AddRoutine(Routine routine);

        void DeleteRoutine(int id);

        IQueryable<Routine> GetAllRoutines();
        void UpdateRoutineWithName(Routine routine);
        void UpdateRoutineWithExercise(int routineId, ExerciseRoutine exerciseRoutine);
    }
}
