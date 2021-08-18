using System.Collections.Generic;

namespace Gymate.Domain.Model
{
    public class ExerciseType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Exercise> Exercises { get; set; }
    }
}
