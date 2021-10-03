using Gymate.Application.Interfaces;
using Gymate.Application.ViewModels.ExerciseTypeVm;
using Gymate.Application.ViewModels.General;
using Gymate.Domain.BOs.ExerciseTypeBOs;
using Gymate.Domain.BOs.General;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

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
        public async Task<ActionResult<PagedResultBO<SingleExerciseTypeBO>>> Get(CancellationToken cancellationToken,
            string searchString = "", int pageSize = 10, int pageNo = 1)
        {
            var model = await _exerciseTypeService.GetAllExerciseTypes(pageSize, pageNo, searchString, cancellationToken);

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
        public async Task<ActionResult> Create([FromBody] NewExerciseTypeVm model, CancellationToken cancellationToken)
        {
            var id = await _exerciseTypeService.AddExerciseType(model, cancellationToken);

            if (id == null)
	        {
                return BadRequest();
	        }

            return Created(nameof(Get), id);
        }

        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateExerciseTypeVm model, CancellationToken cancellationToken)
        {
           var result = await _exerciseTypeService.UpdateExerciseType(id, model, cancellationToken);

            if (result)
            {
                return NoContent();

            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Delete(int id, CancellationToken cancellationToken)
        {
            _exerciseTypeService.DeleteExerciseType(id, cancellationToken);

            return NoContent();
        }
    }
}
