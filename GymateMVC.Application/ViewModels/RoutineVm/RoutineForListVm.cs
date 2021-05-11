using AutoMapper;
using GymateMVC.Application.Mapping;
using GymateMVC.Application.ViewModels.ExerciseVm;
using GymateMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymateMVC.Application.ViewModels.RoutineVm
{
    public class RoutineForListVm : IMapFrom<Routine>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ExerciseForListVm> ExercisesForListVm { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Routine, RoutineForListVm>()
            .ForMember(vm => vm.ExercisesForListVm, opt => opt.MapFrom(model => model.ExerciseRoutines))
            .AfterMap((routine, vm) =>
            {
                foreach (var routineExerciseAndRoutine in routine.ExerciseRoutines)
                {
                    routineExerciseAndRoutine.Routine = routine;
                }
            });

            profile.CreateMap<Exercise, ExerciseForListVm>()
                .ForMember(vm => vm.ExerciseTypeName, opt => opt.MapFrom(model => model.ExerciseType.Name));
        }
    }
}
