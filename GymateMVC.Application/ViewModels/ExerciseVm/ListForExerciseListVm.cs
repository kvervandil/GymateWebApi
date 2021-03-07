using System;
using System.Collections.Generic;
using System.Text;

namespace GymateMVC.Application.ViewModels.ExerciseVm
{
    public class ListForExerciseListVm
    {
        public List<ExerciseForListVm> ListExercisesForList { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public int Count { get; set; }
    }
}
