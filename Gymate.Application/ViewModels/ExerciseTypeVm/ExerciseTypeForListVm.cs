using AutoMapper;
using Gymate.Application.Mapping;
using Gymate.Infrastructure.Entity.Model;

namespace Gymate.Application.ViewModels.ExerciseTypeVm
{
    public class ExerciseTypeForListVm : IMapFrom<ExerciseType>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ExerciseType, ExerciseTypeForListVm>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name));
        }
    }
}
