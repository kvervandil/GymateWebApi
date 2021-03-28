using AutoMapper;
using GymateMVC.Application.Mapping;
using GymateMVC.Application.ViewModels.ExerciseTypeVm;
using GymateMVC.Domain.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymateMVC.Application.ViewModels.RoutineVm
{
    public class NewRoutineVm : IMapFrom<Routine>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Routine, NewRoutineVm>();
        }
    }
}
