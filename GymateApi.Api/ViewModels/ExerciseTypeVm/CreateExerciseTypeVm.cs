using AutoMapper;
using FluentValidation;
using Gymate.Application.Mapping;
using Gymate.Infrastructure.Model;

namespace Gymate.Application.ViewModels.ExerciseTypeVm
{
    public class CreateExerciseTypeVm : IMapFrom<ExerciseType>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ExerciseType, CreateExerciseTypeVm>();
        }
    }

    public class NewExerciseTypeValidation : AbstractValidator<CreateExerciseTypeVm>
    {
        public NewExerciseTypeValidation()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).Length(3, 50);
        }
    }
}
