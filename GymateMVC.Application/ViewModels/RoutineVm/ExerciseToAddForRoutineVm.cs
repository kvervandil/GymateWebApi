using Gymate.Application.ViewModels.ExerciseVm;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Gymate.Application.ViewModels.RoutineVm
{
    public class ExerciseToAddForRoutineVm
    {
        public int RoutineId { get; set; }

        public string RoutineName { get; set; }

        public int ExerciseId { get; set; }
        public List<SelectListItem> SelectListExercise { get; set; }
        public ICollection<ExerciseForListVm> ExercisesForRoutine { get; set; }
    }
}
