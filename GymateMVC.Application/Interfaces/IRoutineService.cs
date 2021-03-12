using GymateMVC.Application.ViewModels.RoutineVm;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymateMVC.Application.Interfaces
{
    public interface IRoutineService
    {
        ListRoutinesForListVm GetAllRoutines();
        int AddRoutine();
        RoutineForListVm GetRoutine();
        void UpdateRoutine();
        void DeleteRoutine();
    }
}
