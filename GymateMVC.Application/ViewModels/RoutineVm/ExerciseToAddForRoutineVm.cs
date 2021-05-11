using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymateMVC.Application.ViewModels.RoutineVm
{
    public class ExerciseToAddForRoutineVm
    {
        public int RoutineId { get; set; }
        public string RoutineName { get; set; }
        public int ExerciseId { get; set; }
        public List<SelectListItem> SelectListExercise { get; set; }
    }
}
