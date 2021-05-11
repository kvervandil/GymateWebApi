using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymateMVC.Application.Interfaces;
using GymateMVC.Application.ViewModels.ExerciseTypeVm;
using GymateMVC.Application.ViewModels.ExerciseVm;
using Microsoft.AspNetCore.Mvc;

namespace GymateMVC.Web.Controllers
{
    public class ExerciseController : Controller
    {
        private IExerciseService _exerciseService;
        private IExerciseTypeService _exerciseTypeService;

        public ExerciseController(IExerciseService exerciseService, IExerciseTypeService exerciseTypeService)
        {
            _exerciseService = exerciseService;
            _exerciseTypeService = exerciseTypeService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _exerciseService.GetAllExercises(10, 1, string.Empty);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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

            var model = _exerciseService.GetAllExercises(pageSize, pageNo.Value, searchString);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddExercise()
        {
            var model = new NewExerciseVm();

            model.SelectListExerciseTypes = _exerciseTypeService.GetSelectListOfAllExerciseTypes();

            return View(model);
        }

        [HttpPost]
        public IActionResult AddExercise(NewExerciseVm model)
        {
            var id = _exerciseService.AddExercise(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditExercise(int id)
        {
            var exercise = _exerciseService.GetExerciseForEdit(id);

            exercise.SelectListExerciseTypes = _exerciseTypeService.GetSelectListOfAllExerciseTypes(exercise.ExerciseTypeId);

            return View(exercise);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditExercise(NewExerciseVm model)
        {
            _exerciseService.UpdateExercise(model);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteExercise(int id)
        {
            _exerciseService.DeleteExercise(id);

            return RedirectToAction("Index");
        }


/*        [HttpGet]
        public IActionResult GetRoutinesForExercise(int exerciseId)
        {
            return View();
        }*/
    }
}
