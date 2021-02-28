using GymateMVC.Domain.Interfaces;
using GymateMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public IQueryable GetExercisesByTypeId(int exerciseTypeId)
        {
            var exercises = _context.Exercises.Where(e => e.ExerciseTypeId == exerciseTypeId);

            return exercises;
        }

        public IQueryable GetExercisesByRoutineId (int routineId)
        {
            var exercises = _context.Exercises.Where(r => r.ExerciseRoutines.Any(er => er.RoutineId == routineId));

            return exercises;
        }
        public IEnumerable<Exercise> GetAllExercises()
        {
            IEnumerable<Exercise> exercises = _context.Exercises;

            return exercises;
        }
    }
}
