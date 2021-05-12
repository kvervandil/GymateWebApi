using GymateMVC.Application.Interfaces;
using GymateMVC.Application.ViewModels.ExerciseVm;
using GymateMVC.Application.ViewModels.RoutineVm;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymateMVC.Web.Controllers
{
    public class RoutineController : Controller
    {
        private readonly IRoutineService _routineService;
        private readonly IExerciseService _exerciseService;
        private readonly IExerciseTypeService _exerciseTypeService;

        public RoutineController(IRoutineService routineService, IExerciseService exerciseService, IExerciseTypeService exerciseTypeService)
        {
            _routineService = routineService;
            _exerciseService = exerciseService;
            _exerciseTypeService = exerciseTypeService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _routineService.GetAllRoutines();

            return View(model);
        }

        [HttpGet]
        public IActionResult AddRoutine()
        {
            var model = new NewRoutineVm();

            return View(model);
        }

        [HttpPost]
        public IActionResult AddRoutine(NewRoutineVm newRoutineVm)
        {
            var id = _routineService.AddRoutine(newRoutineVm);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditRoutine(int id)
        {
            var routine = _routineService.GetRoutineToNameEdit(id);

            return View(routine);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditRoutine(NewRoutineVm model)
        {
            _routineService.UpdateRoutine(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ShowDetails(int id)
        {
            var routine = _routineService.GetRoutine(id);

            return View(routine);
        }

        [HttpGet]
        public IActionResult AddExercise(int routineId)
        {
            ExerciseToAddForRoutineVm model = new ExerciseToAddForRoutineVm();

            model.SelectListExercise = _exerciseService.GetSelectListOfAllExercises();

            model.RoutineId = routineId;            

            var routine = _routineService.GetRoutine(routineId);

            model.RoutineName = routine.Name;

            model.ExercisesForRoutine = routine.ExercisesForListVm;

            return View(model);
        }

        [HttpPost]
        public IActionResult AddExercise(ExerciseToAddForRoutineVm model)
        {
            var id = _routineService.AddExercise(model);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteRoutine(int id)
        {
            _routineService.DeleteRoutine(id);

            return RedirectToAction("Index");
        }
    }
}
