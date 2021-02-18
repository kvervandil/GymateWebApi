using GymateMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymateMVC.Domain.Interfaces
{
    public interface IExerciseTypeRepository
    {
        int AddExerciseType(ExerciseType exerciseType);
        void DeleteExerciseType(int id);
        IEnumerable<ExerciseType> GetAllExerciseTypes();
        ExerciseType GetExerciseTypeById(int id);
        ExerciseType GetExerciseTypeByName(string name);       
    }
}
