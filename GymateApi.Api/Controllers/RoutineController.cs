using AutoMapper;
using Gymate.Application.Interfaces;
using Gymate.Application.ViewModels.RoutineVm;
using Gymate.Domain.BOs.General;
using Gymate.Domain.BOs.RoutineBOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Gymate.Api.Controllers
{
    [Route("api/routines")]
    public class RoutineController : Controller
    {
        private readonly IRoutineService _routineService;
        private readonly IExerciseService _exerciseService;
        private readonly IExerciseTypeService _exerciseTypeService;
        private readonly IMapper _mapper;

        public RoutineController(IRoutineService routineService, IExerciseService exerciseService, IExerciseTypeService exerciseTypeService, IMapper mapper)
        {
            _routineService = routineService;
            _exerciseService = exerciseService;
            _exerciseTypeService = exerciseTypeService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PagedResultBO<SingleRoutineBO>>> GetAll(CancellationToken cancellationToken)
        {
            var model = await _routineService.GetAllRoutines(cancellationToken);

            if (model.Count == 0)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(NewRoutineVm model, CancellationToken cancellationToken)
        {
            var createRoutineBo = _mapper.Map<CreateRoutineBO>(model);

            var id = await _routineService.AddRoutine(createRoutineBo, cancellationToken);

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
        public async Task<ActionResult> Put(NewRoutineVm model, CancellationToken cancellationToken)
        {
            var editRoutineBo = _mapper.Map<EditRoutineBO>(model);

            var result = await _routineService.UpdateRoutine(editRoutineBo, cancellationToken);

            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Get(int id, CancellationToken cancellationToken)
        {
            var routine = _routineService.GetRoutine(id, cancellationToken);

            if (routine is null)
            {
                return NotFound();
            }

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
        public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var result = await _routineService.DeleteRoutine(id, cancellationToken);

            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
