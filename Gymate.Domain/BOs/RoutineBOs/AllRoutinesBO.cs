using System;
using System.Collections.Generic;
using System.Text;

namespace Gymate.Domain.BOs.RoutineBOs
{
    public class AllRoutinesBO
    {
        public List<SingleRoutineBO> RoutinesListBO { get; set; }
        public int Count { get; set; }
    }
}
