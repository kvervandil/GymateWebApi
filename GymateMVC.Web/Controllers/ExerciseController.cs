using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GymateMVC.Web.Controllers
{
    public class ExerciseController : Controller
    {
        public IActionResult Index()
        {
            //create view for exercises
            //table for exercises
            //filter of exercises
            //prepare data
            //provider filters for services
            //prepare by service
            //service prepare data in proper format
            return View();
        }

        [HttpGet]
        public IActionResult AddExercise()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddExercise(ExerciseModel model)
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddLoadToExercise(int exerciseId)
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddLoadToExercise(LoadModel model)
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetRoutinesForExercise(int exerciseId)
        {
            return View();
        }
    }
}
