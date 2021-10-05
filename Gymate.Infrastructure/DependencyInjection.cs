using Gymate.Infrastructure.Interfaces;
using Gymate.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
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

        public static IServiceCollection AddContext(this IServiceCollection services, string connection)
        {
            services.AddDbContext<Context>(options =>
                options.UseSqlServer(
                    connection));

            return services;
        }
    }
}
