﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Gymate.Application.Interfaces;
using Gymate.Application.ViewModels.ExerciseVm;
using Gymate.Application.ViewModels.RoutineVm;
using Gymate.Infrastructure.Entity.Interfaces;
using Gymate.Infrastructure.Entity.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Gymate.Application.Services
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

        public async Task<ListForRoutinesForListVm> GetAllRoutines(CancellationToken cancellationToken)
        {
            var routines = await _routineRepository.GetAllRoutines(cancellationToken);

            var routinesVm = _mapper.Map<List<RoutineForListVm>>(routines); 

            var listForRoutinesListVm = new ListForRoutinesForListVm()
            {
                ListRoutinesForListVm = routinesVm,
                Count = routinesVm.Count
            };

            return listForRoutinesListVm;
        }

        public async Task<int?> AddRoutine(NewRoutineVm model, CancellationToken cancellationToken)
        {
            Routine routine = _mapper.Map<Routine>(model);

            if (string.IsNullOrEmpty(routine.Name))
            {
                return null;
            }

            int id = await _routineRepository.AddRoutine(routine, cancellationToken);

            return id;
        }

        public async Task<bool> DeleteRoutine(int id, CancellationToken cancellationToken)
        {
            try
            {
                return await _routineRepository.DeleteRoutine(id, cancellationToken);

            }
            catch 
            {
                return false;
            }
        }


        public async Task<RoutineForListVm> GetRoutine(int id, CancellationToken cancellationToken)
        {
            var routine = await _routineRepository.GetRoutineById(id, cancellationToken);

            var exercises = await _exerciseRepository.GetExercisesByRoutineId(id, cancellationToken);

            var routineForListVm = _mapper.Map<RoutineForListVm>(routine);

            routineForListVm.ExercisesForListVm = _mapper.Map<List<ExerciseForListVm>>(exercises);

            return routineForListVm;
        }

        public async Task<NewRoutineVm> GetRoutineToNameEdit(int id, CancellationToken cancellationToken)
        {
            var routine = await _routineRepository.GetRoutineById(id, cancellationToken);

            var routineVm = _mapper.Map<NewRoutineVm>(routine);

            return routineVm;
        }

        public async Task<bool> UpdateRoutine(NewRoutineVm routineVm, CancellationToken cancellationToken)
        {
            Routine routine = new Routine
            {
                Id = routineVm.Id,
                Name = routineVm.Name
            };

            return await _routineRepository.UpdateRoutineWithName(routine, cancellationToken);
        }

        public async Task<int?> AddExercise(ExerciseToAddForRoutineVm model, CancellationToken cancellationToken)
        {
            var exercise = await _exerciseRepository.GetExerciseById(model.ExerciseId, cancellationToken);

            var routine = await _routineRepository.GetRoutineById(model.RoutineId, cancellationToken);

            ExerciseRoutine exerciseRoutine = new ExerciseRoutine
            {
                ExerciseId = exercise.Id,
                Exercise = exercise,
                RoutineId = routine.Id,
                Routine = routine,
            };

            await _routineRepository.UpdateRoutineWithExercise(routine.Id, exerciseRoutine, cancellationToken);

            await _exerciseRepository.UpdateExerciseWithExerciseRoutine(exercise, exerciseRoutine, cancellationToken);

            return routine.Id;
        }
    }
}
