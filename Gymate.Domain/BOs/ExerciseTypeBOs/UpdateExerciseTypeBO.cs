using AutoMapper;
using Gymate.Application.Mapping;
using Gymate.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gymate.Domain.BOs.ExerciseTypeBOs
{
    public class UpdateExerciseTypeBO : IMapFrom<ExerciseType>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ExerciseType, UpdateExerciseTypeBO>();
        }
    }
}
