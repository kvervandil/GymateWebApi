using Gymate.Domain.BOs.ExercisesBOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gymate.Domain.BOs.RoutineBOs
{
    public class SingleRoutineBO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SingleExerciseBO> ExercisesBo { get; set; }
    }
}
