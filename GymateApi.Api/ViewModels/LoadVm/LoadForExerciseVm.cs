using AutoMapper;
using Gymate.Application.Mapping;
using Gymate.Domain.BOs.LoadBOs;

namespace Gymate.Application.ViewModels.LoadVm
{
    public class LoadForExerciseVm : IMapFrom<LoadForExerciseBO>
    {
        public int Id { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public int LoadInKg { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LoadForExerciseBO, LoadForExerciseVm>();
        }
    }
}
