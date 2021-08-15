using GymateMVC.Application.Interfaces;
using GymateMVC.Application.ViewModels.ExerciseVm;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymateWebApi.Api.Controllers
{
    [Route("api/exercises")]
    public class ExerciseController : Controller
    {
        private IExerciseService _exerciseService;
        private IExerciseTypeService _exerciseTypeService;

        public ExerciseController(IExerciseService exerciseService, IExerciseTypeService exerciseTypeService)
        {
            _exerciseService = exerciseService;
            _exerciseTypeService = exerciseTypeService;
        }

        // GET: ExerciseController
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Index()
        {
            var model = _exerciseService.GetAllExercises(10, 1, string.Empty);

            if (model.Count == 0)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] NewExerciseVm model)
        {
            var id = _exerciseService.AddExercise(model);

            if (id == 0)
            {
                return BadRequest();
            }

            return Created(nameof(Index), id);
        }

        
        // POST: ExerciseController/Edit/5
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Edit(NewExerciseVm model)
        {             
            _exerciseService.UpdateExercise(model);

            //todo Update to return bool, to check if true
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _exerciseService.DeleteExercise(id);
            
            //todo Update to return bool, to check if true

            return NoContent();
        }
    }
}
