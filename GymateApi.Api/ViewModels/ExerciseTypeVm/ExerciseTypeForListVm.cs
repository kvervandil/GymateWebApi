using AutoMapper;
using Gymate.Application.Mapping;
using Gymate.Domain.BOs.ExerciseTypeBOs;

namespace Gymate.Application.ViewModels.ExerciseTypeVm
{
    public class ExerciseTypeForListVm : IMapFrom<SingleExerciseTypeBO>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SingleExerciseTypeBO, ExerciseTypeForListVm>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name));
        }
    }
}
