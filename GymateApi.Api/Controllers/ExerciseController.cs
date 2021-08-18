using Gymate.Application.Interfaces;
using Gymate.Application.ViewModels.ExerciseVm;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Gymate.Api.Controllers
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
        public IActionResult Get()
        {
            var model = _exerciseService.GetAllExercises(10, 1, string.Empty);

            if (model.Count == 0)
            {
                return NotFound();
            }

            return Ok(model);
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
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(NewExerciseVm model)
        {             
            _exerciseService.UpdateExercise(model);

            //todo Update to return bool, to check if true
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Delete(int id)
        {
            _exerciseService.DeleteExercise(id);
            
            //todo Update to return bool, to check if true

            return NoContent();
        }
    }
}
