using AutoMapper;
using Gymate.Application.Mapping;
using Gymate.Domain.BOs.ExercisesBOs;

namespace Gymate.Application.ViewModels.ExerciseVm
{
    public class ExerciseForListVm : IMapFrom<SingleExerciseBO>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ExerciseTypeName { get; set; }

/*        public void Mapping(Profile profile)
        {
            profile.CreateMap<SingleExerciseBO, ExerciseForListVm>()
                .ForMember(d => d.ExerciseTypeName, opt => opt.MapFrom(s => s.ExerciseType.Name));

            profile.CreateMap<SingleExerciseBO, ExerciseForListVm>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Exercise.Name))
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.ExerciseId))
                .ForMember(d => d.ExerciseTypeName, opt => opt.MapFrom(s => s.Exercise.ExerciseType.Name));

            profile.CreateMap<ExerciseForListVm, SingleExerciseBO>();
        }*/
    }
}
