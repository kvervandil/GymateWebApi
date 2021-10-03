using AutoMapper;
using Gymate.Application.Mapping;
using Gymate.Infrastructure.Model;

namespace Gymate.Domain.BOs.ExercisesBOs
{
    public class SingleExerciseBO : IMapFrom<Exercise>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ExerciseTypeName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Exercise, SingleExerciseBO>()
                .ForMember(d => d.ExerciseTypeName, opt => opt.MapFrom(s => s.ExerciseType.Name));

            profile.CreateMap<ExerciseRoutine, SingleExerciseBO>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Exercise.Name))
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.ExerciseId))
                .ForMember(d => d.ExerciseTypeName, opt => opt.MapFrom(s => s.Exercise.ExerciseType.Name));

            profile.CreateMap<SingleExerciseBO, Exercise>();
        }
    }
}
