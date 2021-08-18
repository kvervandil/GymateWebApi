using AutoMapper;
using Gymate.Application.Mapping;
using Gymate.Application.ViewModels.ExerciseVm;
using Gymate.Domain.Model;
using System.Collections.Generic;

namespace Gymate.Application.ViewModels.RoutineVm
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
