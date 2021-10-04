using AutoMapper;
using Gymate.Application.Mapping;
using Gymate.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gymate.Domain.BOs.RoutineBOs
{
    public class CreateRoutineBO : IMapFrom<Routine>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Routine, CreateRoutineBO>();
        }
    }
}
