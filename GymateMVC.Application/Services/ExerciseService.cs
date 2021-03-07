using GymateMVC.Application.Interfaces;
using GymateMVC.Application.ViewModels.ExerciseTypeVm;
using GymateMVC.Application.ViewModels.ExerciseVm;
using GymateMVC.Domain.Interfaces;
using GymateMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymateMVC.Application.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository _exerciseRepo;
        private readonly IExerciseTypeRepository _exerciseTypeRepo;

        public ExerciseService(IExerciseRepository exerciseRepository, IExerciseTypeRepository exerciseTypeRepository)
        {
            _exerciseRepo = exerciseRepository;
            _exerciseTypeRepo = exerciseTypeRepository;
        }

        public int AddExercise(NewExerciseVm newExerciseVm)
        {
            var exerciseType = _exerciseTypeRepo.GetExerciseTypeById(newExerciseVm.ExerciseTypeId);

            var exercise = new Exercise
            {
                Id = newExerciseVm.Id,
                Name = newExerciseVm.Name,
                ExerciseType = exerciseType,
                ExerciseTypeId = exerciseType.Id
            };

            _exerciseRepo.AddExercise(exercise);

            return exercise.Id;
        }

        public ListForExerciseListVm GetAllExercises(int pageSize, int pageNo, string searchString)
        {
            ListForExerciseListVm listForExercisesListVm = new ListForExerciseListVm
            {
                ListExercisesForList = new List<ExerciseForListVm>()
            };

            var exercises = _exerciseRepo.GetAllExercises().Where(e => e.Name.StartsWith(searchString));

            var exercisesToShow = exercises.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();

            foreach (var exercise in exercisesToShow)
            {
                ExerciseForListVm exerciseForListVm = new ExerciseForListVm()
                {
                    Id = exercise.Id,
                    Name = exercise.Name,
                    ExerciseTypeName = exercise.ExerciseType.Name
                };

                listForExercisesListVm.ListExercisesForList.Add(exerciseForListVm);
            }
            listForExercisesListVm.Count = exercises.Count();
            listForExercisesListVm.CurrentPage = pageNo;
            listForExercisesListVm.PageSize = pageSize;
            listForExercisesListVm.SearchString = searchString;

            return listForExercisesListVm;
        }

        public ExerciseForListVm GetExercise(int id)
        {
            var exercise = _exerciseRepo.GetExerciseById(id);

            ExerciseForListVm exerciseForListVm = new ExerciseForListVm()
            {
                Id = exercise.Id,
                Name = exercise.Name,
                ExerciseTypeName = exercise.ExerciseType.Name
            };

            return exerciseForListVm;
        }

        public NewExerciseVm GetExerciseForEdit(int id)
        {
            var exercise = _exerciseRepo.GetExerciseById(id);

            NewExerciseVm newExerciseVm = new NewExerciseVm() { 
                Id = exercise.Id,
                Name = exercise.Name,
                ExerciseTypeId = exercise.ExerciseTypeId,
            };

            return newExerciseVm;
        }

        public void UpdateExercise(NewExerciseVm model)
        {
            ExerciseType exerciseType = _exerciseTypeRepo.GetExerciseTypeById(model.ExerciseTypeId);

            Exercise exercise = new Exercise()
            {
                Id = model.Id,
                ExerciseTypeId = model.ExerciseTypeId,
                Name = model.Name,
                ExerciseType = exerciseType
            };

            _exerciseRepo.UpdateExercise(exercise);
        }

        public void DeleteExercise(int id)
        {
            _exerciseRepo.DeleteExercise(id);
        }
    }
}
