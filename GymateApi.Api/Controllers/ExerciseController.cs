using AutoMapper;
using Gymate.Api.ViewModels.General;
using Gymate.Application.Interfaces;
using Gymate.Application.ViewModels.ExerciseVm;
using Gymate.Domain.BOs.ExerciseBOs;
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
        private readonly IMapper _mapper;

        public ExerciseController(IExerciseService exerciseService, IExerciseTypeService exerciseTypeService, IMapper mapper)
        {
            _exerciseService = exerciseService;
            _exerciseTypeService = exerciseTypeService;

            _mapper = mapper;
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
            var exerciseBO = _mapper.Map<CreateExerciseBO>(model);

            var id = await _exerciseService.AddExercise(exerciseBO, cancellationToken);

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
            var exerciseBO = _mapper.Map<EditExerciseBO>(model);

            var result = await _exerciseService.UpdateExercise(id, exerciseBO, cancellationToken);

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
