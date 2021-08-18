using Gymate.Domain.Model;
using System.Linq;

namespace Gymate.Domain.Interfaces
{
    public interface IExerciseTypeRepository
    {
        int AddExerciseType(ExerciseType exerciseType);
        void DeleteExerciseType(int id);
        IQueryable<ExerciseType> GetAllExerciseTypes();
        ExerciseType GetExerciseTypeById(int id);
        ExerciseType GetExerciseTypeByName(string name);
        void UpdateExerciseType(ExerciseType exerciseType);
        IQueryable<ExerciseType> GetExerciseTypesWithExercises();
    }
}
