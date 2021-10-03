using AutoMapper;
using Gymate.Application.Mapping;
using Gymate.Infrastructure.Entity.Model;

namespace Gymate.Application.ViewModels.RoutineVm
{
    public class NewRoutineVm : IMapFrom<Routine>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Routine, NewRoutineVm>();
        }
    }
}
