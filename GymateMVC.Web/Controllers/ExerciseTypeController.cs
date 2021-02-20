using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymateMVC.Application.Interfaces;
using GymateMVC.Application.ViewModels.ExerciseTypeVm;
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
            var model = _exerciseTypeService.GetAllExerciseTypes(2, 1, string.Empty);

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int pageSize, int? pageNo, string searchString) 
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }
            if (searchString is null)
            {
                searchString = string.Empty;
            }
            var model = _exerciseTypeService.GetAllExerciseTypes(pageSize, pageNo.Value, searchString);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddExerciseType()
        {
            return View(new NewExerciseTypeVm());
        }

        [HttpPost]
        public IActionResult AddExerciseType(NewExerciseTypeVm model)
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
