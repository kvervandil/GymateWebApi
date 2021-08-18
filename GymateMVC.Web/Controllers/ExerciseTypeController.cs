using Gymate.Application.Interfaces;
using Gymate.Application.ViewModels.ExerciseTypeVm;
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
        public IActionResult Index()
        {
            var model = _exerciseTypeService.GetAllExerciseTypes(10, 1, string.Empty);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(int pageSize, int? pageNo, string searchString) 
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }
            if (searchString is null)
            {
                searchString = string.Empty;
            }
            var model = _exerciseTypeService.GetAllExerciseTypes(pageSize, pageNo.Value, searchString);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddExerciseType()
        {
            return View(new NewExerciseTypeVm());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddExerciseType(NewExerciseTypeVm model)
        {
            var id = _exerciseTypeService.AddExerciseType(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditExerciseType(int id)
        {
            var exerciseType = _exerciseTypeService.GetExerciseTypeForEdit(id);

            return View(exerciseType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditExerciseType(NewExerciseTypeVm model)
        {
            _exerciseTypeService.UpdateExerciseType(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetExercisesForExerciseType(int exerciseTypeId) 
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            _exerciseTypeService.DeleteExerciseType(id);

            return RedirectToAction("Index");
        }
    }
}
