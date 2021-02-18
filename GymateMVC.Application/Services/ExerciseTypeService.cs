using GymateMVC.Application.Interfaces;
using GymateMVC.Application.ViewModels.ExerciseTypeVm;
using GymateMVC.Domain.Interfaces;
using GymateMVC.Domain.Model;
using System;
using System.Collections.Generic;
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

        public ListForExerciseTypeListVm GetAllExerciseTypes()
        {
            ListForExerciseTypeListVm listForExerciseTypeListVm = new ListForExerciseTypeListVm();

            var exerciseTypes = _exerciseTypeRepo.GetAllExerciseTypes();

            listForExerciseTypeListVm.ListForExerciseTypeList = new List<ExerciseTypeForListVm>();

            foreach (var exerciseType in exerciseTypes)
            {
                var exerciseTypeForListVm = new ExerciseTypeForListVm()
                {
                    Id = exerciseType.Id,
                    Name = exerciseType.Name,
                };

                listForExerciseTypeListVm.ListForExerciseTypeList.Add(exerciseTypeForListVm);
            }

            listForExerciseTypeListVm.Count = listForExerciseTypeListVm.ListForExerciseTypeList.Count;

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
