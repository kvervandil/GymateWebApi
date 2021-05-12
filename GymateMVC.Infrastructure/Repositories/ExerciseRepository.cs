using GymateMVC.Domain.Interfaces;
using GymateMVC.Domain.Model;
using System.Linq;

namespace GymateMVC.Infrastructure.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly Context _context;

        public ExerciseRepository(Context context)
        {
            _context = context;
        }

        public void DeleteExercise(int exerciseId)
        {
            var exercise = _context.Exercises.Find(exerciseId);

            if (exercise != null)
            {
                _context.Exercises.Remove(exercise);
                _context.SaveChanges();
            }
        }

        public int AddExercise(Exercise exercise)
        {
            _context.Exercises.Add(exercise);
            _context.SaveChanges();

            return exercise.Id;
        }

        public Exercise GetExerciseById(int id)
        {
            Exercise exercise = _context.Exercises.FirstOrDefault(e => e.Id == id);

            return exercise;
        }

        public IQueryable<Exercise> GetExercisesByTypeId(int exerciseTypeId)
        {
            var exercises = _context.Exercises.Where(e => e.ExerciseTypeId == exerciseTypeId);

            return exercises;
        }

        public IQueryable<Exercise> GetExercisesByRoutineId (int routineId)
        {
            var exercises = _context.Exercises.Where(r => r.ExerciseRoutines.Any(er => er.RoutineId == routineId));

            return exercises;
        }
        public IQueryable<Exercise> GetAllExercises()
        {
            IQueryable<Exercise> exercises = _context.Exercises;

            return exercises;
        }

        public void UpdateExercise(Exercise exercise)
        {
            _context.Attach(exercise);
            _context.Entry(exercise).Property("Name").IsModified = true;
            _context.Entry(exercise).Property("ExerciseTypeId").IsModified = true;

            _context.SaveChanges();
        }

        public void UpdateExerciseWithExerciseRoutine(Exercise exercise, ExerciseRoutine exerciseRoutine)
        {
            exercise.ExerciseRoutines.Add(exerciseRoutine);

            _context.Attach(exercise);

            _context.SaveChanges();
        }
    }
}
