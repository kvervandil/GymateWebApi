using AutoMapper;
using FluentValidation;
using Gymate.Application.Mapping;
using Gymate.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gymate.Domain.BOs.ExerciseTypeBOs
{
    public class CreateExerciseTypeBO : IMapFrom<ExerciseType>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ExerciseType, CreateExerciseTypeBO>();
        }
    }

    public class NewExerciseTypeValidation : AbstractValidator<CreateExerciseTypeBO>
    {
        public NewExerciseTypeValidation()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).Length(3, 50);
        }
    }
}
