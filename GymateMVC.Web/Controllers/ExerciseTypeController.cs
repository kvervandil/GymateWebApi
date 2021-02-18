using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymateMVC.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GymateMVC.Web.Controllers
{
    public class ExerciseTypeController : Controller
    {
        private readonly IExerciseTypeService _exerciseTypeService;

        public ExerciseTypeController(IExerciseTypeService exerciseTypeService)
        {
            _exerciseTypeService = exerciseTypeService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _exerciseTypeService.GetAllExerciseTypes();

            return View(model);
        }

        [HttpGet]
        public IActionResult AddExerciseType()
        {
            return View();
        }

/*        [HttpPost]
        public IActionResult AddExerciseType(ExerciseModel model)
        {
            return View();
        }*/

        [HttpGet]
        public IActionResult GetExercisesForExerciseType(int exerciseTypeId) 
        {
            return View();
        }


    }
}
