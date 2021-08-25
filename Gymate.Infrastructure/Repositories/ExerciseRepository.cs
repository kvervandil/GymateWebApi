using Gymate.Infrastructure.Entity.Interfaces;
using Gymate.Infrastructure.Entity.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Gymate.Infrastructure.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly Context _context;

        public ExerciseRepository(Context context)
        {
            _context = context;
        }

        public async Task<bool> DeleteExercise(int exerciseId, CancellationToken cancellationToken)
        {
            //var exercise = _context.Exercises.Find(exerciseId);

            var exercise = GetExerciseById(exerciseId, cancellationToken);

            if (exercise is null)
            {
                return false;
            }

            _context.Remove(exercise);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<int> AddExercise(Exercise exercise, CancellationToken cancellationToken)
        {
            await _context.Exercises.AddAsync(exercise, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return exercise.Id;
        }

        public async Task<Exercise> GetExerciseById(int id, CancellationToken cancellationToken)
        {
            return await _context.Exercises.SingleOrDefaultAsync(ex => ex.Id == id, cancellationToken);
        }

        public IQueryable<Exercise> GetExercisesByTypeId(int exerciseTypeId)
        {
            var exercises = _context.Exercises.Where(e => e.ExerciseTypeId == exerciseTypeId);

            return exercises;
        }

        public async Task<List<Exercise>> GetExercisesByRoutineId (int routineId, CancellationToken cancellationToken)
        {
            var exercises = await _context.Exercises.Where(r => r.ExerciseRoutines.Any(er => er.RoutineId == routineId))
                .ToListAsync(cancellationToken);

            return exercises;
        }
        public async Task<List<Exercise>> GetAllExercises(int pageSize, int pageNo, string searchString,
            CancellationToken cancellationToken)
        {
            var exercises = _context.Exercises.AsQueryable();

            var exercisesFiltered = exercises.Where(p => p.Name.StartsWith(searchString));

            return await exercisesFiltered.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToListAsync(cancellationToken);
        }

        public async Task<bool> UpdateExercise(Exercise exercise, CancellationToken cancellationToken)
        {
            try
            {
                var exerciseToUpdate = await GetExerciseById(exercise.Id, cancellationToken);

                exerciseToUpdate.Name = exercise.Name;
                exerciseToUpdate.Load = exercise.Load;
                exerciseToUpdate.ExerciseType = exercise.ExerciseType;
                exerciseToUpdate.ExerciseTypeId = exercise.ExerciseTypeId;

                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch
            {
                //todo add logger, custom exception
                return false;
            }
        }

        public async Task<bool> UpdateExerciseWithExerciseRoutine(Exercise exercise, ExerciseRoutine exerciseRoutine, CancellationToken cancellationToken)
        { 
            try
            {
                var exerciseToUpdate = await GetExerciseById(exercise.Id, cancellationToken);

                exerciseToUpdate.ExerciseRoutines.Add(exerciseRoutine);

                await _context.SaveChangesAsync(cancellationToken);

                return true;
            }
            catch
            {

                return false;
            }
        }

        public async Task<int> GetNoOfExercises(CancellationToken cancellationToken)
        {
            return await _context.Exercises.CountAsync(cancellationToken);
        }
    }
}
