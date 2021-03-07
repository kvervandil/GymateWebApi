using GymateMVC.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace GymateMVC.Domain.Interfaces
{
    public interface IExerciseRepository
    {
        void DeleteExercise(int exerciseId);

        int AddExercise(Exercise exercise);

        Exercise GetExerciseById(int id);

        IQueryable GetExercisesByTypeId(int exerciseTypeId);

        IQueryable GetExercisesByRoutineId(int routineId);
        IQueryable<Exercise> GetAllExercises();
        void UpdateExercise(Exercise exercise);
    }
}
