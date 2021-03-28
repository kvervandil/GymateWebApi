using AutoMapper;
using GymateMVC.Application.Mapping;
using GymateMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymateMVC.Application.ViewModels.LoadVm
{
    public class LoadForExerciseVm : IMapFrom<LoadForExercise>
    {
        public int Id { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public int LoadInKg { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LoadForExercise, LoadForExerciseVm>();
        }
    }
}
