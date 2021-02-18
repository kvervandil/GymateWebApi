using GymateMVC.Domain.Interfaces;
using GymateMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymateMVC.Infrastructure.Repositories
{
    public class ExerciseTypeRepository : IExerciseTypeRepository
    {
        private readonly Context _context;

        public ExerciseTypeRepository(Context context)
        {
            _context = context;
        }

        public int AddExerciseType(ExerciseType exerciseType)
        {
            _context.Add(exerciseType);

            _context.SaveChanges();

            return exerciseType.Id;
        }

        public void DeleteExerciseType(int id)
        {
            var exerciseType = GetExerciseTypeById(id);

            if (exerciseType != null)
            {
                _context.ExerciseTypes.Remove(exerciseType);
                _context.SaveChanges();
            }
        }

        public IEnumerable<ExerciseType> GetAllExerciseTypes()
        {
            return _context.ExerciseTypes;
        }

        public ExerciseType GetExerciseTypeById(int id)
        {
            var exerciseType = _context.ExerciseTypes.Find(id);

            return exerciseType;
        }

        public ExerciseType GetExerciseTypeByName(string name)
        {
            var exerciseType = _context.ExerciseTypes.FirstOrDefault(et => et.Name == name);

            return exerciseType;
        }

    }
}
