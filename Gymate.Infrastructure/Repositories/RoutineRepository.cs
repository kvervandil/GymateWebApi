using Gymate.Domain.Interfaces;
using Gymate.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Gymate.Infrastructure.Repositories
{
    public class RoutineRepository : IRoutineRepository
    {
        private readonly Context _context;

        public RoutineRepository(Context context)
        {
            _context = context;
        }

        public Routine GetRoutineById(int id)
        {
            //Routine routine = _context.Routines.Find(id);

            var routine = _context.Routines.Where(routine => routine.Id == id)
                .Include(routine => routine.ExerciseRoutines)
                .SingleOrDefault();

            //Routine routine = _context.Routines.Include(routine => routine.ExerciseRoutines).FirstOrDefault(routine => routine.Id == id);
            
            return routine;
        }

        public int AddRoutine(Routine routine)
        {
            _context.Routines.Add(routine);

            _context.SaveChanges();

            return routine.Id;
        }

        public void DeleteRoutine(int id)
        {
            var routine = GetRoutineById(id);
            var exerciseRoutine = GetExerciseRoutineByRoutineId(id);

            if (routine != null)
            {
                _context.Routines.Remove(routine);

                _context.ExerciseRoutine.RemoveRange(exerciseRoutine);

                _context.SaveChanges();
            }
        }

        private ExerciseRoutine GetExerciseRoutineByRoutineId(int id)
        {
            return _context.ExerciseRoutine.Find(id);
            //return _context.ExerciseRoutine.Where(er => er.RoutineId == id);
        }

        public void UpdateRoutineWithExercise(int routineId, ExerciseRoutine exerciseRoutine)
        {
            var routine = GetRoutineById(routineId);

            _context.ExerciseRoutine.Add(exerciseRoutine);

            routine.ExerciseRoutines.Add(exerciseRoutine);

            _context.Attach(routine);

            _context.SaveChanges();
        }

        public IQueryable<Routine> GetAllRoutines()
        {
            return _context.Routines;
        }

        public void UpdateRoutineWithName(Routine routine)
        {
            _context.Attach(routine);

            _context.Entry(routine).Property("Name").IsModified = true;

            _context.SaveChanges();
        }
    }
}
