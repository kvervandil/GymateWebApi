using GymateMVC.Application.ViewModels.RoutineVm;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymateMVC.Application.Interfaces
{
    public interface IRoutineService
    {
        ListForRoutinesForListVm GetAllRoutines();
        int AddRoutine(NewRoutineVm model);
        RoutineForListVm GetRoutine(int id);
        void UpdateRoutine(NewRoutineVm routineVm);
        void DeleteRoutine(int id);
        NewRoutineVm GetRoutineToNameEdit(int id);
    }
}
