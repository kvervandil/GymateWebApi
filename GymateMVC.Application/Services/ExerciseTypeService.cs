using AutoMapper;
using AutoMapper.QueryableExtensions;
using Gymate.Application.Interfaces;
using Gymate.Application.ViewModels.ExerciseTypeVm;
using Gymate.Domain.Interfaces;
using Gymate.Domain.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

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

        public ListForExerciseTypeListVm GetAllExerciseTypes(int pageSize, int pageNo, string searchString)
        {
            var exerciseTypes = _exerciseTypeRepo.GetAllExerciseTypes().Where(et => et.Name.StartsWith(searchString))
                .ProjectTo<ExerciseTypeForListVm>(_mapper.ConfigurationProvider).ToList();

            var exerciseTypesToShow = exerciseTypes.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            var listForExerciseTypesToShow = new List<ExerciseTypeForListVm>();

            ListForExerciseTypeListVm listForExerciseTypeListVm = new ListForExerciseTypeListVm()
            {
                ListForExerciseTypeList = exerciseTypesToShow,
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                Count = exerciseTypes.Count()
            };

            return listForExerciseTypeListVm;
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
