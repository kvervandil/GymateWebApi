using Gymate.Application.ViewModels.RoutineVm;

namespace Gymate.Application.Interfaces
{
    public interface IRoutineService
    {
        ListForRoutinesForListVm GetAllRoutines();
        int AddRoutine(NewRoutineVm model);
        RoutineForListVm GetRoutine(int id);
        void UpdateRoutine(NewRoutineVm routineVm);
        void DeleteRoutine(int id);
        NewRoutineVm GetRoutineToNameEdit(int id);
        int AddExercise(ExerciseToAddForRoutineVm model);
    }
}
