using Gymate.Application.Interfaces;
using Gymate.Application.ViewModels.RoutineVm;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gymate.Api.Controllers
{
    [Route("api/routines")]
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
        public ActionResult Get()
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
        public ActionResult Create(NewRoutineVm model)
        {
            var id = _routineService.AddRoutine(model);

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
        public ActionResult Put(NewRoutineVm model)
        {
            _routineService.UpdateRoutine(model);

            return NoContent();
        }

        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Get(int id)
        {
            var routine = _routineService.GetRoutine(id);

            return Ok(routine);
        }

/*        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Create(ExerciseToAddForRoutineVm model)
        {
            var id = _routineService.AddExercise(model);

            if (id == 0)
            {
                return BadRequest();
            }

            return Created(nameof(Get), id);
        }*/

        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Delete(int id)
        {
            _routineService.DeleteRoutine(id);

            return NoContent();
        }
    }
}
