using AutoMapper;
using FluentValidation;
using Gymate.Application.Mapping;
using Gymate.Infrastructure.Entity.Model;

namespace Gymate.Application.ViewModels.ExerciseTypeVm
{
    public class NewExerciseTypeVm : IMapFrom<ExerciseType>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ExerciseType, NewExerciseTypeVm>();
        }
    }

    public class NewExerciseTypeValidation : AbstractValidator<NewExerciseTypeVm>
    {
        public NewExerciseTypeValidation()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).Length(3, 50);
        }
    }
}
