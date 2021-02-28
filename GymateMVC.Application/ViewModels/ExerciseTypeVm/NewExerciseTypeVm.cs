using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymateMVC.Application.ViewModels.ExerciseTypeVm
{
    public class NewExerciseTypeVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
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
