using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GymateMVC.Web.Controllers
{
    public class ExerciseTypeController : Controller
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
        public IActionResult AddExerciseType()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddExerciseType(ExerciseModel model)
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetExercisesForExerciseType(int exerciseTypeId) 
        {
            return View();
        }


    }
}
