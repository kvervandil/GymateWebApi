using AutoMapper;
using AutoMapper.QueryableExtensions;
using Gymate.Application.Interfaces;
using Gymate.Application.ViewModels.ExerciseVm;
using Gymate.Application.ViewModels.RoutineVm;
using Gymate.Infrastructure.Entity.Interfaces;
using Gymate.Infrastructure.Entity.Model;
using System.Linq;

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

            var exercises = _exerciseRepository.GetExercisesByRoutineId(id);

            var routineForListVm = _mapper.Map<RoutineForListVm>(routine);

            routineForListVm.ExercisesForListVm = exercises.ProjectTo<ExerciseForListVm>(_mapper.ConfigurationProvider).ToList();

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

        public int AddExercise(ExerciseToAddForRoutineVm model)
        {
            var exercise = _exerciseRepository.GetExerciseById(model.ExerciseId);

            var routine = _routineRepository.GetRoutineById(model.RoutineId);

            ExerciseRoutine exerciseRoutine = new ExerciseRoutine
            {
                ExerciseId = exercise.Id,
                Exercise = exercise,
                RoutineId = routine.Id,
                Routine = routine,
            };

            _routineRepository.UpdateRoutineWithExercise(routine.Id, exerciseRoutine);

            _exerciseRepository.UpdateExerciseWithExerciseRoutine(exercise, exerciseRoutine);

            return routine.Id;
        }
    }
}
