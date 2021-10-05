using AutoMapper;
using Gymate.Application.Mapping;
using Gymate.Domain.BOs.ExerciseBOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Gymate.Application.ViewModels.ExerciseVm
{
    public class NewExerciseVm : IMapFrom<CreateExerciseBO>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ExerciseTypeId { get; set; }
        public List<SelectListItem> SelectListExerciseTypes { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateExerciseBO, NewExerciseVm>();
        }
    }
}
