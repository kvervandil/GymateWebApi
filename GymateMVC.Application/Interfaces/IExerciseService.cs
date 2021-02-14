using GymateMVC.Application.ViewModels.ExerciseVm;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymateMVC.Application.Interfaces
{
    public interface IExerciseService
    {
        ListExerciseForListVm GetAllExercisesForList();
        int AddExercise(NewExerciseVm newExerciseVm);
        ExerciseForListVm GetExercise(int id);
    }
}
