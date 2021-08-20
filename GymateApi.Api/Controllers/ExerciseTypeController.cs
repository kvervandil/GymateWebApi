using Gymate.Application.Interfaces;
using Gymate.Application.ViewModels.ExerciseTypeVm;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Gymate.Api.Controllers
{
    [Route("api/exerciseTypes")]
    public class ExerciseTypeController : Controller
    {
        private readonly IExerciseTypeService _exerciseTypeService;
        private readonly ILogger<ExerciseTypeController> _logger;

        public ExerciseTypeController(IExerciseTypeService exerciseTypeService, ILogger<ExerciseTypeController> loger)
        {
            _exerciseTypeService = exerciseTypeService;
            _logger = loger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Get()
        {
            var model = _exerciseTypeService.GetAllExerciseTypes(10, 1, string.Empty);

            if (model.Count == 0)
	        {
                return NotFound();
	        }

            return Ok(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Create(NewExerciseTypeVm model)
        {
            var id = _exerciseTypeService.AddExerciseType(model);

            if (id == 0)
	        {
                return BadRequest();
	        }

            return Created(nameof(Get), id);
        }

        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Put([FromBody] NewExerciseTypeVm model)
        {
            _exerciseTypeService.UpdateExerciseType(model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Delete(int id)
        {
            _exerciseTypeService.DeleteExerciseType(id);

            return NoContent();
        }
    }
}
