using AutoMapper;
using Gymate.Application.Mapping;
using Gymate.Infrastructure.Model;

namespace Gymate.Domain.BOs.ExerciseBOs
{
    public class ExerciseForRoutineBO : IMapFrom<Exercise>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public ICollection<LoadForExerciseVm> Load { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ExerciseForRoutineBO, Exercise>();

        }
    }
}
