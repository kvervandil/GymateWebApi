using AutoMapper;
using Gymate.Application.Mapping;
using Gymate.Infrastructure.Entity.Model;

namespace Gymate.Application.ViewModels.ExerciseVm
{
    public class ExerciseForListVm : IMapFrom<Exercise>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ExerciseTypeName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Exercise, ExerciseForListVm>()
                .ForMember(d => d.ExerciseTypeName, opt => opt.MapFrom(s => s.ExerciseType.Name));

            profile.CreateMap<ExerciseRoutine, ExerciseForListVm>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Exercise.Name))
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.ExerciseId))
                .ForMember(d => d.ExerciseTypeName, opt => opt.MapFrom(s => s.Exercise.ExerciseType.Name));

            profile.CreateMap<ExerciseForListVm, Exercise>();
        }
    }
}
