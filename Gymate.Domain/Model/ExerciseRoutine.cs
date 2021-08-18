namespace Gymate.Domain.Model
{
    public class ExerciseRoutine
    {
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
        public int RoutineId { get; set; }
        public Routine Routine { get; set; }
    }
}
