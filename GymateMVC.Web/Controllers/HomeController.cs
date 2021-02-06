using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GymateMVC.Web.Models;

namespace GymateMVC.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewListOfExercises()
        {
            List<ExerciseDemo> exercises = new List<ExerciseDemo>();

            exercises.Add(new ExerciseDemo() { Id = 1, Name = "Squat", TypeName = "Legs" });
            exercises.Add(new ExerciseDemo() { Id = 2, Name = "Bench press", TypeName = "Chest" });
            exercises.Add(new ExerciseDemo() { Id = 3, Name = "Ohp", TypeName = "Shoulders" });

            return View(exercises);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
