using AutoMapper;
using Gymate.Application.Mapping;
using Gymate.Application.ViewModels.LoadVm;
using Gymate.Domain.BOs.ExerciseBOs;
using System.Collections.Generic;

namespace Gymate.Application.ViewModels.ExerciseVm
{
    public class ExerciseForRoutineVm : IMapFrom<ExerciseForRoutineBO>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<LoadForExerciseVm> Load { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ExerciseForRoutineBO, ExerciseForRoutineVm>();
            
        }
    }
}
