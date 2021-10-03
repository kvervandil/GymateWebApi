using System;
using System.Collections.Generic;
using System.Text;

namespace Gymate.Domain.BOs.ExercisesBOs
{
    public class AllExercisesBO
    {
        public List<SingleExerciseBO> ExercisesForList { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public int Count { get; set; }
    }
}
