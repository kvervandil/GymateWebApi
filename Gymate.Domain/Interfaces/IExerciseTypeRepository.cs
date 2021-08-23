using Gymate.Infrastructure.Entity.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Gymate.Infrastructure.Entity.Interfaces
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
        Task<List<ExerciseType>> GetExerciseTypes(int pageSize, int pageNo, string searchString, CancellationToken cancellationToken);
        Task<int> GetNoOfExerciseTypes(CancellationToken cancellationToken);
    }
}
