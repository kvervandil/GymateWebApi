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

        public int AddExerciseType(NewExerciseTypeVm newExerciseType)
        {
            var exerciseType = new ExerciseType
            {
                Id = newExerciseType.Id,
                Name = newExerciseType.Name
            };

            var id = _exerciseTypeRepo.AddExerciseType(exerciseType);

            return id;
        }

        public void DeleteExerciseType(int id)
        {
            _exerciseTypeRepo.DeleteExerciseType(id);
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

        public NewExerciseTypeVm GetExerciseTypeForEdit(int id)
        {
            var exerciseType = _exerciseTypeRepo.GetExerciseTypeById(id);

            var newExerciseTypeVm = _mapper.Map<NewExerciseTypeVm>(exerciseType);

            return newExerciseTypeVm;
        }

        public void UpdateExerciseType(NewExerciseTypeVm model)
        {
            ExerciseType exerciseType = new ExerciseType
            {
                Id = model.Id,
                Name = model.Name,
            };

            _exerciseTypeRepo.UpdateExerciseType(exerciseType);
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
