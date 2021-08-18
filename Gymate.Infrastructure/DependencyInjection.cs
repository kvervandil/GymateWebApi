using Gymate.Domain.Interfaces;
using Gymate.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Gymate.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IExerciseTypeRepository, ExerciseTypeRepository>();
            services.AddTransient<IExerciseRepository, ExerciseRepository>();
            services.AddTransient<IRoutineRepository, RoutineRepository>();

            return services;
        }
    }
}
