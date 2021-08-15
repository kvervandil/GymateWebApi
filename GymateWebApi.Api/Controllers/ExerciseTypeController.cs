using GymateMVC.Application.Interfaces;
using GymateMVC.Application.ViewModels.ExerciseTypeVm;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GymateMVC.Web.Controllers
{
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
        public IActionResult Get()
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
        public IActionResult Create(NewExerciseTypeVm model)
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
        public IActionResult Put([FromBody] NewExerciseTypeVm model)
        {
            _exerciseTypeService.UpdateExerciseType(model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _exerciseTypeService.DeleteExerciseType(id);

            return NoContent();
        }
    }
}
