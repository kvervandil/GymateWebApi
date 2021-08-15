using GymateMVC.Application.Interfaces;
using GymateMVC.Application.ViewModels.ExerciseVm;
using GymateMVC.Application.ViewModels.RoutineVm;
using Microsoft.AspNetCore.Http;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            var model = _routineService.GetAllRoutines();

            if (model.Count == 0)
	        {
                return NotFound();
	        }

            return Ok(model);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(NewRoutineVm newRoutineVm)
        {
            var id = _routineService.AddRoutine(newRoutineVm);

            if (id == 0)
	        {
                return BadRequest();
	        }

            return Created(nameof(Get), id);
        }

        [HttpPut("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ValidateAntiForgeryToken]
        public IActionResult EditRoutine(NewRoutineVm model)
        {
            _routineService.UpdateRoutine(model);

            return NoContent();
        }

        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Details(int id)
        {
            var routine = _routineService.GetRoutine(id);

            return Ok(routine);
        }
                
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddExercise(ExerciseToAddForRoutineVm model)
        {
            var id = _routineService.AddExercise(model);

            if(id == 0)
            {
                return BadRequest();
            }

            return Created(nameof(Get), id);
        }

        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteRoutine(int id)
        {
            _routineService.DeleteRoutine(id);

            return NoContent();
        }
    }
}
