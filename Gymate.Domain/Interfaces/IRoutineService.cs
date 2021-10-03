using Gymate.Application.ViewModels.RoutineVm;
using System.Threading;
using System.Threading.Tasks;

namespace Gymate.Application.Interfaces
{
    public interface IRoutineService
    {
        Task<ListForRoutinesForListVm> GetAllRoutines(CancellationToken cancellationToken);
        Task<int?> AddRoutine(NewRoutineVm model, CancellationToken cancellationToken);
        Task<RoutineForListVm> GetRoutine(int id, CancellationToken cancellationToken);
        Task<bool> UpdateRoutine(NewRoutineVm routineVm, CancellationToken cancellationToken);
        Task<bool> DeleteRoutine(int id, CancellationToken cancellationToken);
        Task<NewRoutineVm> GetRoutineToNameEdit(int id, CancellationToken cancellationToken);
        Task<int?> AddExercise(ExerciseToAddForRoutineVm model, CancellationToken cancellationToken);
    }
}
