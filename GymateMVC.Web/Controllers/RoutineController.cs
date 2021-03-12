using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymateMVC.Web.Controllers
{
    public class RoutineController : Controller
    {
        public IActionResult Index()
        {
            //Get All Routines

            return View();
        }

        public IActionResult AddRoutine()
        {
            return View();
        }

        public IActionResult EditRoutine()
        {
            return View();
        }

        public IActionResult DeleteRoutine()
        {
            return View();
        }
    }
}
