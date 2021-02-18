using GymateMVC.Application.Interfaces;
using GymateMVC.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymateMVC.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IExerciseTypeService, ExerciseTypeService>();
            services.AddTransient<IExerciseService, ExerciseService>();

            return services;
        }
    }
}
