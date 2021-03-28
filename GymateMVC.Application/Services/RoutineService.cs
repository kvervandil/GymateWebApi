using AutoMapper;
using AutoMapper.QueryableExtensions;
using GymateMVC.Application.Interfaces;
using GymateMVC.Application.ViewModels.ExerciseVm;
using GymateMVC.Application.ViewModels.RoutineVm;
using GymateMVC.Domain.Interfaces;
using GymateMVC.Domain.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymateMVC.Application.Services
{
    class RoutineService : IRoutineService
    {
        private readonly IRoutineRepository _routineRepository;
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IMapper _mapper;

        public RoutineService(IRoutineRepository routineRepository, IExerciseRepository exerciseRepository, IMapper mapper)
        {
            _routineRepository = routineRepository;
            _exerciseRepository = exerciseRepository;
            _mapper = mapper;
        }

        public int AddRoutine(NewRoutineVm model)
        {
            var routine = new Routine
            {
                Id = model.Id,
                Name = model.Name
            };

            _routineRepository.AddRoutine(routine);

            return routine.Id;
        }

        public void DeleteRoutine(int id)
        {
            _routineRepository.DeleteRoutine(id);
        }

        public ListForRoutinesForListVm GetAllRoutines()
        {
            var routines = _routineRepository.GetAllRoutines();
            var routinesVm = routines.ProjectTo<RoutineForListVm>(_mapper.ConfigurationProvider).ToList();

            var listForRoutinesListVm = new ListForRoutinesForListVm()
            {
                ListRoutinesForListVm = routinesVm,
                Count = routinesVm.Count
            };

            return listForRoutinesListVm;
        }

        public RoutineForListVm GetRoutine(int id)
        {
            var routine = _routineRepository.GetRoutineById(id);

            var exercises = _exerciseRepository.GetExercisesByRoutineId(id).ProjectTo<ExerciseForListVm>(_mapper.ConfigurationProvider).ToList();

            var routineForListVm = _mapper.Map<RoutineForListVm>(routine);

            routineForListVm.ExercisesForListVm = exercises;

            return routineForListVm;
        }

        public NewRoutineVm GetRoutineToNameEdit(int id)
        {
            var routine = _routineRepository.GetRoutineById(id);

            var routineVm = _mapper.Map<NewRoutineVm>(routine);

            return routineVm;
        }

        public void UpdateRoutine(NewRoutineVm routineVm)
        {
            Routine routine = new Routine
            {
                Id = routineVm.Id,
                Name = routineVm.Name
            };

            _routineRepository.UpdateRoutineWithName(routine);
        }
    }
}
