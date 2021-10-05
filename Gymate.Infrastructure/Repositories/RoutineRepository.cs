using Gymate.Infrastructure.Interfaces;
using Gymate.Infrastructure.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Gymate.Infrastructure.Repositories
{
    public class RoutineRepository : IRoutineRepository
    {
        private readonly Context _context;

        public RoutineRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<Routine>> GetAllRoutines(CancellationToken cancellationToken)
        {
            var routines = _context.Routines.AsQueryable();

            return await routines.ToListAsync(cancellationToken);
        }

        public async Task<Routine> GetRoutineById(int id, CancellationToken cancellationToken)
        {
            Routine routine = await _context.Routines.Include(routine => routine.ExerciseRoutines).SingleOrDefaultAsync(routine => routine.Id == id,
                                                                                                                        cancellationToken);
            return routine;
        }

        public async Task<int> AddRoutine(Routine routine, CancellationToken cancellationToken)
        {
            await _context.Routines.AddAsync(routine, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return routine.Id;
        }

        public async Task<bool> DeleteRoutine(int id, CancellationToken cancellationToken)
        {
            var routine = await GetRoutineById(id, cancellationToken);
            var exerciseRoutine = GetExerciseRoutineByRoutineId(id);

            if (routine != null)
            {
                _context.Routines.Remove(routine);

                _context.ExerciseRoutine.RemoveRange(exerciseRoutine);

                _context.SaveChanges();

                return true;
            }

            return false;
        }

        private ExerciseRoutine GetExerciseRoutineByRoutineId(int id)
        {
            return _context.ExerciseRoutine.Find(id);
            //return _context.ExerciseRoutine.Where(er => er.RoutineId == id);
        }

        public async Task<bool> UpdateRoutineWithExercise(int routineId, ExerciseRoutine exerciseRoutine, CancellationToken cancellationToken)
        {
            try
            {
                var routine = await GetRoutineById(routineId, cancellationToken);

                await _context.ExerciseRoutine.AddAsync(exerciseRoutine, cancellationToken);

                routine.ExerciseRoutines.Add(exerciseRoutine);

                await _context.SaveChangesAsync(cancellationToken);

                return true;
            }
            catch 
            {
                return false;
            }
        }

        public async Task<bool> UpdateRoutineWithName(Routine routine, CancellationToken cancellationToken)
        {
            try
            {
                var routineToUpdate = await GetRoutineById(routine.Id, cancellationToken);

                routineToUpdate.Name = routine.Name;
                await _context.SaveChangesAsync(cancellationToken);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
