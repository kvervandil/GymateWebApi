using AutoMapper;
using FluentValidation;
using GymateMVC.Application.Mapping;
using GymateMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymateMVC.Application.ViewModels.ExerciseTypeVm
{
    public class NewExerciseTypeVm : IMapFrom<ExerciseType>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ExerciseType, NewExerciseTypeVm>();
        }
    }

    public class NewExerciseTypeValidation : AbstractValidator<NewExerciseTypeVm>
    {
        public NewExerciseTypeValidation()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).Length(3, 50);
        }
    }
}
