using AutoMapper;
using Gymate.Application.Mapping;
using Gymate.Domain.BOs.ExerciseTypeBOs;
using Gymate.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gymate.Domain.BOs.ExerciseBOs
{
    public class CreateExerciseBO : IMapFrom<Exercise>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ExerciseTypeId { get; set; }
        public List<SingleExerciseTypeBO> SelectListExerciseTypes { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Exercise, CreateExerciseBO>();
        }
    }
}
