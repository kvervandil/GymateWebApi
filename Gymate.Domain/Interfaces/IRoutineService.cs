using Gymate.Application.ViewModels.RoutineVm;
using Gymate.Domain.BOs.RoutineBOs;
using System.Threading;
using System.Threading.Tasks;

namespace Gymate.Application.Interfaces
{
    public interface IRoutineService
    {
        Task<AllRoutinesBO> GetAllRoutines(CancellationToken cancellationToken);
        Task<int?> AddRoutine(CreateRoutineBO model, CancellationToken cancellationToken);
        Task<SingleRoutineBO> GetRoutine(int id, CancellationToken cancellationToken);
        Task<bool> UpdateRoutine(EditRoutineBO routineVm, CancellationToken cancellationToken);
        Task<bool> DeleteRoutine(int id, CancellationToken cancellationToken);
        Task<EditRoutineBO> GetRoutineToNameEdit(int id, CancellationToken cancellationToken);
        Task<int?> AddExercise(ExerciseToAddForRoutineVm model, CancellationToken cancellationToken);
    }
}
