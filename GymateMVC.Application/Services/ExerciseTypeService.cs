using GymateMVC.Application.Interfaces;
using GymateMVC.Application.ViewModels.ExerciseTypeVm;
using GymateMVC.Application.ViewModels.ExerciseVm;
using GymateMVC.Domain.Interfaces;
using GymateMVC.Domain.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymateMVC.Application.Services
{
    public class ExerciseTypeService : IExerciseTypeService
    {
        private readonly IExerciseTypeRepository _exerciseTypeRepo;

        public ExerciseTypeService(IExerciseTypeRepository exerciseTypeRepository)
        {
            _exerciseTypeRepo = exerciseTypeRepository;
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
            var exerciseTypes = _exerciseTypeRepo.GetAllExerciseTypes().Where(et => et.Name.StartsWith(searchString));
            var exerciseTypesToShow = exerciseTypes.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            var listForExerciseTypesToShow = new List<ExerciseTypeForListVm>();

            foreach (var exerciseType in exerciseTypesToShow)
            {
                var exerciseTypeForListVm = new ExerciseTypeForListVm()
                {
                    Id = exerciseType.Id,
                    Name = exerciseType.Name,
                };

                listForExerciseTypesToShow.Add(exerciseTypeForListVm);
            }

            ListForExerciseTypeListVm listForExerciseTypeListVm = new ListForExerciseTypeListVm()
            {
                ListForExerciseTypeList = listForExerciseTypesToShow,
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

            var newExerciseTypeVm = new NewExerciseTypeVm
            {
                Id = exerciseType.Id,
                Name = exerciseType.Name
            };

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

        public List<SelectListItem> GetSelectListOfAllExerciseTypes(int chosenExerciseTypeId)
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
    }
}
