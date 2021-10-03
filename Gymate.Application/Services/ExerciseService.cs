using AutoMapper;
using Gymate.Application.Interfaces;
using Gymate.Domain.BOs.ExerciseBOs;
using Gymate.Domain.BOs.ExercisesBOs;
using Gymate.Domain.BOs.General;
using Gymate.Infrastructure.Entity.Interfaces;
using Gymate.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Gymate.Application.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository _exerciseRepo;
        private readonly IExerciseTypeRepository _exerciseTypeRepo;
        private readonly IMapper _mapper;

        public ExerciseService(IExerciseRepository exerciseRepository,
                               IExerciseTypeRepository exerciseTypeRepository,
                               IMapper mapper)
        {
            _exerciseRepo = exerciseRepository;
            _exerciseTypeRepo = exerciseTypeRepository;
            _mapper = mapper;
        }

        public async Task<int?> AddExercise(NewExerciseBO newExerciseBO, CancellationToken cancellationToken)
        {
            var exerciseType = await _exerciseTypeRepo.GetExerciseTypeById(newExerciseBO.ExerciseTypeId, new CancellationToken());

            var exercise = _mapper.Map<Exercise>(newExerciseBO);

            exercise.ExerciseType = exerciseType;
            exercise.ExerciseTypeId = exerciseType.Id;

            if (string.IsNullOrEmpty(exercise.Name))
            {
                return null;
            }

            int id = await _exerciseRepo.AddExercise(exercise, cancellationToken);

            return id;
        }

        public async Task<PagedResultBO<AllExercisesBO>> GetAllExercises(int pageSize, int pageNo, string searchString,
            CancellationToken cancellationToken)
        {
            var exercises = await _exerciseRepo.GetAllExercises(pageSize, pageNo, searchString, cancellationToken);

            var noOfExercises = await _exerciseRepo.GetNoOfExercises(cancellationToken);

            var exercisesVm = _mapper.Map<List<AllExercisesBO>>(exercises);

            var exercisesForList = new PagedResultBO<AllExercisesBO>
            {
                Items = exercisesVm,
                CurentPage = pageNo,
                Count = noOfExercises,
                PageSize = pageNo
            };

            return exercisesForList;
        }

        public async Task<SingleExerciseBO> GetExercise(int id, CancellationToken cancellationToken)
        {
            var exercise = await _exerciseRepo.GetExerciseById(id, cancellationToken);

            if (exercise is null)
            {
                return null;
            }

            var exerciseVm = _mapper.Map<SingleExerciseBO>(exercise);

            return exerciseVm;
        }

        public async Task<EditExerciseBO> GetExerciseForEdit(int id, CancellationToken cancellationToken)
        {
            var exercise = await _exerciseRepo.GetExerciseById(id, cancellationToken);

            var newExerciseVm = _mapper.Map<EditExerciseBO>(exercise);

            return newExerciseVm;
        }

        public async Task<bool> UpdateExercise(int id, EditExerciseBO model, CancellationToken cancellationToken)
        {
            if (model is null)
            {
                return false;
            }

            ExerciseType exerciseType = await _exerciseTypeRepo.GetExerciseTypeById(model.ExerciseTypeId, cancellationToken);

            Exercise exercise = _mapper.Map<Exercise>(model);
            exercise.ExerciseType = exerciseType;
            exercise.Id = id;

            return await _exerciseRepo.UpdateExercise(exercise, cancellationToken);
        }

        public async Task<bool> DeleteExercise(int id, CancellationToken cancellationToken)
        {
            try
            { 
                return await _exerciseRepo.DeleteExercise(id, cancellationToken);
            }
            catch
            {
                //todo add logger
                return false;
            }
        }
    }
}
