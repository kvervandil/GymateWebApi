using AutoMapper;
using FluentValidation;
using Gymate.Application.Mapping;
using Gymate.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gymate.Domain.BOs.ExerciseTypeBOs
{
    public class CreateExerciseTypeBo : IMapFrom<ExerciseType>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ExerciseType, CreateExerciseTypeBo>();
        }
    }

    public class NewExerciseTypeValidation : AbstractValidator<CreateExerciseTypeBo>
    {
        public NewExerciseTypeValidation()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).Length(3, 50);
        }
    }
}
