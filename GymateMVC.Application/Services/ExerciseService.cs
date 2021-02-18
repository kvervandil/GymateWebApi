using GymateMVC.Application.Interfaces;
using GymateMVC.Application.ViewModels.ExerciseTypeVm;
using GymateMVC.Application.ViewModels.ExerciseVm;
using GymateMVC.Domain.Interfaces;
using GymateMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymateMVC.Application.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository _exerciseRepo;

        public ExerciseService(IExerciseRepository exerciseRepository)
        {
            _exerciseRepo = exerciseRepository;
        }

        public int AddExercise(NewExerciseVm newExerciseVm, ExerciseTypeForListVm exerciseTypeForListVm)
        {
            ExerciseType exerciseType = new ExerciseType
            {
                Id = exerciseTypeForListVm.Id,
                Name = exerciseTypeForListVm.Name
            };

            var exercise = new Exercise
            {
                Id = newExerciseVm.Id,
                Name = newExerciseVm.Name,                
                ExerciseType = exerciseType,
                ExerciseTypeId = exerciseTypeForListVm.Id
            };

            _exerciseRepo.AddExercise(exercise);

            return exercise.Id;
        }

        public ListForExercisesListVm GetAllExercises()
        {
            ListForExercisesListVm listForExercisesListVm = new ListForExercisesListVm
            {
                ListExercisesForList = new List<ExerciseForListVm>()
            };

            var exercises = _exerciseRepo.GetAllExercises();

            foreach (var exercise in exercises)
            {
                ExerciseForListVm exerciseForListVm = new ExerciseForListVm()
                {
                    Id = exercise.Id,
                    Name = exercise.Name,
                    ExerciseTypeName = exercise.ExerciseType.Name
                };

                listForExercisesListVm.ListExercisesForList.Add(exerciseForListVm);
            }
            listForExercisesListVm.Count = listForExercisesListVm.ListExercisesForList.Count;

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
    }
}
