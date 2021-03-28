using AutoMapper;
using GymateMVC.Application.Mapping;
using GymateMVC.Application.ViewModels.LoadVm;
using GymateMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymateMVC.Application.ViewModels.ExerciseVm
{
    public class ExerciseForRoutineVm : IMapFrom<Exercise>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<LoadForExerciseVm> Load { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Exercise, ExerciseForRoutineVm>();
            
        }
    }
}
