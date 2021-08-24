using Gymate.Application.Interfaces;
using Gymate.Application.ViewModels.ExerciseVm;
using Gymate.Application.ViewModels.General;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

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
        public async Task<ActionResult<PagedResultDto<ExerciseForListVm>>> Get(CancellationToken cancellationToken,
            string searchString = "", int pageSize = 10, int pageNo = 1)
        {
            var model = await _exerciseService.GetAllExercises(pageSize, pageNo, searchString, cancellationToken);

            if (model.Count == 0)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create([FromBody] NewExerciseVm model, CancellationToken cancellationToken)
        {
            var id = await _exerciseService.AddExercise(model, cancellationToken);

            if (id is null)
            {
                return BadRequest();
            }

            return Created(nameof(Index), id);
        }

        
        // POST: ExerciseController/Edit/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Put(int id, [FromBody] NewExerciseVm model, CancellationToken cancellationToken)
        {             
            var result = await _exerciseService.UpdateExercise(id, model, cancellationToken);

            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var result = await _exerciseService.DeleteExercise(id, cancellationToken);

            if (result)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
