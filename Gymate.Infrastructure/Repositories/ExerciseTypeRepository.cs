using Gymate.Infrastructure.Entity.Interfaces;
using Gymate.Infrastructure.Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Gymate.Infrastructure.Repositories
{
    public class ExerciseTypeRepository : IExerciseTypeRepository
    {
        private readonly Context _context;

        public ExerciseTypeRepository(Context context)
        {
            _context = context;
        }

        public async Task<int> AddExerciseType(ExerciseType exerciseType, CancellationToken cancellationToken)
        {
            await _context.AddAsync(exerciseType, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return exerciseType.Id;
        }

        public async Task<bool> DeleteExerciseType(int id, CancellationToken cancellationToken)
        {
            var exerciseType = await GetExerciseTypeById(id, cancellationToken);

            if (exerciseType != null)
            {
                _context.ExerciseTypes.Remove(exerciseType);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<List<ExerciseType>> GetExerciseTypes(int pageSize, int pageNo, string searchString, CancellationToken cancellationToken)
        {
            var exerciseTypes = _context.ExerciseTypes.AsQueryable();

            var exerciseTypesFiltered = exerciseTypes.Where(p => p.Name.StartsWith(searchString));

            return await exerciseTypesFiltered.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToListAsync(cancellationToken);
        }
        public async Task<int> GetNoOfExerciseTypes(CancellationToken cancellationToken)
        {
            return await _context.ExerciseTypes.CountAsync(cancellationToken);
        }

        public IQueryable<ExerciseType> GetAllExerciseTypes()
        {
            return _context.ExerciseTypes;
        }

        public IQueryable<ExerciseType> GetExerciseTypesWithExercises()
        {
            return _context.ExerciseTypes.Include(et => et.Exercises);
        }

        public async Task<ExerciseType> GetExerciseTypeById(int id, CancellationToken cancellationToken)
        {
            return await _context.ExerciseTypes.SingleOrDefaultAsync(et => et.Id == id, cancellationToken);
        }

        public ExerciseType GetExerciseTypeByName(string name)
        {
            var exerciseType = _context.ExerciseTypes.FirstOrDefault(et => et.Name == name);

            return exerciseType;
        }

        public async Task<bool> UpdateExerciseType(ExerciseType exerciseType, CancellationToken cancellationToken)
        {
            try
            {
                var exerciseTypeToUpdate = await GetExerciseTypeById(exerciseType.Id, cancellationToken);

                exerciseTypeToUpdate.Name = exerciseType.Name;

                await _context.SaveChangesAsync(cancellationToken);

                return true;
            }
            catch
            {
                //todo logger to be added
                return false;
            }
        }        
    }
}
