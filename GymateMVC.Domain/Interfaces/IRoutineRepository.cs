using GymateMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymateMVC.Domain.Interfaces
{
    public interface IRoutineRepository
    {
        Routine GetRoutineById(int id);

        int AddRoutine(Routine routine);

        void DeleteRoutine(int id);

        IEnumerable<Routine> GetAllRoutines();
    }
}
