using GymateMVC.Domain.Interfaces;
using GymateMVC.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymateMVC.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IExerciseTypeRepository, ExerciseTypeRepository>();
            services.AddScoped<IExerciseRepository, ExerciseRepository>();

            return services;
        }
    }
}
