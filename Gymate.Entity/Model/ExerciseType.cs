using System.Collections.Generic;

namespace Gymate.Infrastructure.Entity.Model
{
    public class ExerciseType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Exercise> Exercises { get; set; }
    }
}
