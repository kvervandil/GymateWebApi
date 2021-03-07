using GymateMVC.Application.ViewModels.ExerciseTypeVm;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymateMVC.Application.ViewModels.ExerciseVm
{
    public class NewExerciseVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ExerciseTypeId { get; set; }

        public List<ExerciseTypeForNewExerciseVm> ListOfExerciseTypes { get; set; }

        public List<SelectListItem> SelectListExerciseTypes { get; set; }
    }
}
