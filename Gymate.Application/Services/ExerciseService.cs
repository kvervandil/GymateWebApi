using AutoMapper;
using AutoMapper.QueryableExtensions;
using Gymate.Application.Interfaces;
using Gymate.Application.ViewModels.ExerciseVm;
using Gymate.Application.ViewModels.General;
using Gymate.Infrastructure.Entity.Interfaces;
using Gymate.Infrastructure.Entity.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public async Task<int?> AddExercise(NewExerciseVm newExerciseVm, CancellationToken cancellationToken)
        {
            var exerciseType = await _exerciseTypeRepo.GetExerciseTypeById(newExerciseVm.ExerciseTypeId, new CancellationToken());

            var exercise = _mapper.Map<Exercise>(newExerciseVm);

            exercise.ExerciseType = exerciseType;
            exercise.ExerciseTypeId = exerciseType.Id;

            if (string.IsNullOrEmpty(exercise.Name))
            {
                return null;
            }

            int id = await _exerciseRepo.AddExercise(exercise, cancellationToken);

            return id;
        }

        public async Task<PagedResultDto<ExerciseForListVm>> GetAllExercises(int pageSize, int pageNo, string searchString,
            CancellationToken cancellationToken)
        {
            var exercises = await _exerciseRepo.GetAllExercises(pageSize, pageNo, searchString, cancellationToken);

            var noOfExercises = await _exerciseRepo.GetNoOfExercises(cancellationToken);

            var exercisesVm = _mapper.Map<List<ExerciseForListVm>>(exercises);

            var exercisesForList = new PagedResultDto<ExerciseForListVm>
            {
                Items = exercisesVm,
                CurentPage = pageNo,
                Count = noOfExercises,
                PageSize = pageNo
            };

            return exercisesForList;
        }

        public async Task<ExerciseForListVm> GetExercise(int id, CancellationToken cancellationToken)
        {
            var exercise = await _exerciseRepo.GetExerciseById(id, cancellationToken);

            if (exercise is null)
            {
                return null;
            }

            var exerciseVm = _mapper.Map<ExerciseForListVm>(exercise);

            return exerciseVm;
        }

        public async Task<NewExerciseVm> GetExerciseForEdit(int id, CancellationToken cancellationToken)
        {
            var exercise = await _exerciseRepo.GetExerciseById(id, cancellationToken);

            var newExerciseVm = _mapper.Map<NewExerciseVm>(exercise);

            return newExerciseVm;
        }

        public async Task<bool> UpdateExercise(int id, NewExerciseVm model, CancellationToken cancellationToken)
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

        public async Task<List<SelectListItem>> GetSelectListOfAllExercises(int chosenExerciseId = 0)
        {
            List<SelectListItem> selectedItems = new List<SelectListItem>();

            var exercises = await _exerciseRepo.GetAllExercises(10, 1, "", new CancellationToken());

            foreach(var exercise in exercises)
            {
                SelectListItem selectedExercise = new SelectListItem { Value = exercise.Id.ToString(), Text = exercise.Name };

                if (exercise.Id == chosenExerciseId)
                {
                    selectedExercise.Selected = true;
                }

                selectedItems.Add(selectedExercise);
            }

            return selectedItems;
        }
    }
}
