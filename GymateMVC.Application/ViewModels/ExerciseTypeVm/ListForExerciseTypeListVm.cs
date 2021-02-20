using System;
using System.Collections.Generic;
using System.Text;

namespace GymateMVC.Application.ViewModels.ExerciseTypeVm
{
    public class ListForExerciseTypeListVm
    {
        public List<ExerciseTypeForListVm> ListForExerciseTypeList { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public int Count { get; set; }
    }
}
