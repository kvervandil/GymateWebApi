using AutoMapper;
using GymateMVC.Application.Mapping;
using GymateMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymateMVC.Application.ViewModels.ExerciseVm
{
    public class ExerciseForListVm : IMapFrom<Exercise>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ExerciseTypeName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Exercise, ExerciseForListVm>()
                .ForMember(d => d.ExerciseTypeName, opt => opt.MapFrom(s => s.ExerciseType.Name));

            profile.CreateMap<ExerciseRoutine, ExerciseForListVm>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Exercise.Name))
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.ExerciseId))
                .ForMember(d => d.ExerciseTypeName, opt => opt.MapFrom(s => s.Exercise.ExerciseType.Name));

            profile.CreateMap<ExerciseForListVm, Exercise>();
        }
    }
}
