using Gymate.Application.Interfaces;
using Gymate.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Gymate.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IExerciseTypeService, ExerciseTypeService>();
            services.AddTransient<IExerciseService, ExerciseService>();
            services.AddTransient<IRoutineService, RoutineService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
