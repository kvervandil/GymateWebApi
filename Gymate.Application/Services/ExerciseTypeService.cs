using AutoMapper;
using AutoMapper.QueryableExtensions;
using Gymate.Application.Interfaces;
using Gymate.Application.ViewModels.ExerciseTypeVm;
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
    public class ExerciseTypeService : IExerciseTypeService
    {
        private readonly IExerciseTypeRepository _exerciseTypeRepo;
        private readonly IMapper _mapper;

        public ExerciseTypeService(IExerciseTypeRepository exerciseTypeRepository, IMapper mapper)
        {
            _exerciseTypeRepo = exerciseTypeRepository;
            _mapper = mapper;
        }

        public async Task<int?> AddExerciseType(NewExerciseTypeVm newExerciseType, CancellationToken cancellationToken)
        {
            var exerciseType = _mapper.Map<ExerciseType>(newExerciseType);

            if (string.IsNullOrEmpty(exerciseType.Name))                
            {
                return null;
            }

            int id = await _exerciseTypeRepo.AddExerciseType(exerciseType, cancellationToken);

            return id;
        }

        public void DeleteExerciseType(int id, CancellationToken cancellationToken)
        {
            _exerciseTypeRepo.DeleteExerciseType(id, cancellationToken);
        }

        public async Task<PagedResultDto<ExerciseTypeForListVm>> GetAllExerciseTypes(int pageSize, int pageNo, string searchString, CancellationToken cancellationToken)
        {
            var exerciseTypes = await _exerciseTypeRepo.GetExerciseTypes(pageSize, pageNo, searchString, cancellationToken);

            var noOfExerciseTypes = await _exerciseTypeRepo.GetNoOfExerciseTypes(cancellationToken);

            var exerciseTypesVm = _mapper.Map<List<ExerciseTypeForListVm>>(exerciseTypes);

            var exerciseTypesForList = new PagedResultDto<ExerciseTypeForListVm>
            {
                Items = exerciseTypesVm,
                CurentPage = pageNo,
                Count = noOfExerciseTypes,
                PageSize = pageSize
            };

            return exerciseTypesForList;
        }

        public NewExerciseTypeVm GetExerciseTypeForEdit(int id, CancellationToken cancellationToken)
        {
            var exerciseType = _exerciseTypeRepo.GetExerciseTypeById(id, cancellationToken);

            var newExerciseTypeVm = _mapper.Map<NewExerciseTypeVm>(exerciseType);

            return newExerciseTypeVm;
        }

        public async Task<bool> UpdateExerciseType(int id, UpdateExerciseTypeVm model, CancellationToken cancellationToken)
        {
            if (model is null)
            {
                return false;
            }

            ExerciseType exerciseType = _mapper.Map<ExerciseType>(model);

            exerciseType.Id = id;

            return await _exerciseTypeRepo.UpdateExerciseType(exerciseType, cancellationToken);
        }

        public List<SelectListItem> GetSelectListOfAllExerciseTypes(int chosenExerciseTypeId = 0)
        {
            List<SelectListItem> selectedItems = new List<SelectListItem>();

            var exerciseTypes = _exerciseTypeRepo.GetAllExerciseTypes();

            foreach (var exerciseType in exerciseTypes)
            {
                SelectListItem selectedExerciseType = new SelectListItem { Value = exerciseType.Id.ToString(), Text = exerciseType.Name };

                if (exerciseType.Id == chosenExerciseTypeId)
                {
                    selectedExerciseType.Selected = true;
                }

                selectedItems.Add(selectedExerciseType);
            }

            return selectedItems;
        }

        public ListOfExerciseTypesWithExercisesForRoutine GetAllExerciseTypesWithExercises()
        {
            var listOfExericeTypes = new ListOfExerciseTypesWithExercisesForRoutine();

            var exerciseTypes = _exerciseTypeRepo.GetExerciseTypesWithExercises()
                .ProjectTo<ExerciseTypeWithExercisesForRoutineVm>(_mapper.ConfigurationProvider).ToList();

            listOfExericeTypes.ListExerciseTypesForRoutine = exerciseTypes;
            listOfExericeTypes.Count = exerciseTypes.Count;

            return listOfExericeTypes;
        }
    }
}
