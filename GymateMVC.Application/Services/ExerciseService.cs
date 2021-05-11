using AutoMapper;
using AutoMapper.QueryableExtensions;
using GymateMVC.Application.Interfaces;
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
            var exercises = _exerciseRepo.GetAllExercises().Where(e => e.Name.StartsWith(searchString))
                .ProjectTo<ExerciseForListVm>(_mapper.ConfigurationProvider).ToList();

            var exercisesToShow = exercises.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();

            ListForExerciseListVm listForExercisesListVm = new ListForExerciseListVm
            {
                Count = exercises.Count(),
                CurrentPage = pageNo,
                PageSize = pageSize,
                SearchString = searchString,
                ListExercisesForList = exercisesToShow
            };

            return listForExercisesListVm;
        }

        public ExerciseForListVm GetExercise(int id)
        {
            var exercise = _exerciseRepo.GetExerciseById(id);

            var exerciseForListVm = _mapper.Map<ExerciseForListVm>(exercise);

            return exerciseForListVm;
        }

        public NewExerciseVm GetExerciseForEdit(int id)
        {
            var exercise = _exerciseRepo.GetExerciseById(id);

            var newExerciseVm = _mapper.Map<NewExerciseVm>(exercise);

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

        public List<SelectListItem> GetSelectListOfAllExercises(int chosenExerciseId = 0)
        {
            List<SelectListItem> selectedItems = new List<SelectListItem>();

            var exercises = _exerciseRepo.GetAllExercises();

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
