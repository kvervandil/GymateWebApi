using AutoMapper;
using Gymate.Application.Mapping;
using Gymate.Domain.BOs.RoutineBOs;

namespace Gymate.Application.ViewModels.RoutineVm
{
    public class NewRoutineVm : IMapFrom<CreateRoutineBO>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateRoutineBO, NewRoutineVm>();
        }
    }
}
