using GymateMVC.Application.ViewModels.ExerciseVm;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymateMVC.Application.Interfaces
{
    public interface IExerciseService
    {
        ListForExerciseListVm GetAllExercises(int pageSize, int pageNo, string searchString);
        int AddExercise(NewExerciseVm newExerciseVm);
        ExerciseForListVm GetExercise(int id);
        NewExerciseVm GetExerciseForEdit(int id);
        void UpdateExercise(NewExerciseVm model);
        void DeleteExercise(int id);
        List<SelectListItem> GetSelectListOfAllExercises(int chosenExerciseId = 0);
    }
}
