using GymateMVC.Application.Interfaces;
using GymateMVC.Application.ViewModels.ExerciseTypeVm;
using GymateMVC.Domain.Interfaces;
using GymateMVC.Domain.Model;
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
            var exerciseType = new ExerciseType();
            exerciseType.Id = newExerciseType.Id;
            exerciseType.Name = newExerciseType.Name;

            _exerciseTypeRepo.AddExerciseType(exerciseType);

            return exerciseType.Id;
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

        public ExerciseTypeForListVm GetExerciseType(int id)
        {
            var exerciseType = _exerciseTypeRepo.GetExerciseTypeById(id);

            var exerciseTypeForListVm = new ExerciseTypeForListVm();

            exerciseTypeForListVm.Id = exerciseType.Id;
            exerciseTypeForListVm.Name = exerciseType.Name;

            return exerciseTypeForListVm;
        }

        public ExerciseTypeForListVm GetExerciseType(string name)
        {
            var exerciseType = _exerciseTypeRepo.GetExerciseTypeByName(name);

            var exerciseTypeForListVm = new ExerciseTypeForListVm();

            exerciseTypeForListVm.Id = exerciseType.Id;
            exerciseTypeForListVm.Name = exerciseType.Name;

            return exerciseTypeForListVm;
        }
    }
}
