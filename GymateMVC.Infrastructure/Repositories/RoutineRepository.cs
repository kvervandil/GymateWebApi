using GymateMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymateMVC.Infrastructure.Repositories
{
    public class RoutineRepository
    {
        private readonly Context _context;

        public RoutineRepository(Context context)
        {
            _context = context;
        }

        public Routine GetRoutineById(int id)
        {
            Routine routine = _context.Routines.Find(id);

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

            if (routine != null)
            {
                _context.Routines.Remove(routine);

                _context.SaveChanges();
            }
        }

        public IEnumerable<Routine> GetAllRoutines()
        {
            return _context.Routines;
        }
    }
}
