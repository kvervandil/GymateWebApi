using AutoMapper;
using Gymate.Application.Mapping;
using Gymate.Application.ViewModels.ExerciseVm;
using Gymate.Domain.BOs.ExerciseTypeBOs;
using System.Collections.Generic;

namespace Gymate.Application.ViewModels.ExerciseTypeVm
{
    public class ExerciseTypeWithExercisesForRoutineVm : IMapFrom<EditExerciseTypeBO>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ExerciseForRoutineVm> Exercises { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<EditExerciseTypeBO, ExerciseTypeWithExercisesForRoutineVm>();
        }
    }
}
