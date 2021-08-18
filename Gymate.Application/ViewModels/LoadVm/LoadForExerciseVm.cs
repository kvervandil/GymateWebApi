using AutoMapper;
using Gymate.Application.Mapping;
using Gymate.Domain.Model;

namespace Gymate.Application.ViewModels.LoadVm
{
    public class LoadForExerciseVm : IMapFrom<LoadForExercise>
    {
        public int Id { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public int LoadInKg { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LoadForExercise, LoadForExerciseVm>();
        }
    }
}
