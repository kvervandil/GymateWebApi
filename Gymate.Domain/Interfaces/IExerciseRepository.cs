using Gymate.Infrastructure.Entity.Model;
using System.Linq;

namespace Gymate.Infrastructure.Entity.Interfaces
{
    public interface IExerciseRepository
    {
        void DeleteExercise(int exerciseId);

        int AddExercise(Exercise exercise);
        Exercise GetExerciseById(int id);
        IQueryable<Exercise> GetExercisesByTypeId(int exerciseTypeId);
        IQueryable<Exercise> GetExercisesByRoutineId(int routineId);
        IQueryable<Exercise> GetAllExercises();
        void UpdateExercise(Exercise exercise);
        void UpdateExerciseWithExerciseRoutine(Exercise exercise, ExerciseRoutine exerciseRoutine);
    }
}
