using AutoMapper;
using GymateMVC.Application.Mapping;
using GymateMVC.Application.ViewModels.ExerciseVm;
using GymateMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymateMVC.Application.ViewModels.ExerciseTypeVm
{
    public class ExerciseTypeWithExercisesForRoutineVm : IMapFrom<ExerciseType>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ExerciseForRoutineVm> Exercises { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ExerciseType, ExerciseTypeWithExercisesForRoutineVm>();
        }
    }
}
