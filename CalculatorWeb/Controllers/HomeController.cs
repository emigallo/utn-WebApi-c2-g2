using CalculatorWeb.Models;
using CalculatorWeb.Services;
using CalculatorWeb.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace CalculatorWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Create(UserModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Calc");
            }

            ViewBag.Error = "Hay campos sin completar";
            return View("Welcome", model);
        }

        [HttpGet]
        [Route("Calc")]
        public IActionResult Calc()
        {
            var model = new CalcViewModel();
            return View(model);
        }

        [HttpPost]
        [Route("Calc")]
        public IActionResult Calculate(CalcViewModel model, string lastInput)
        {
            var service = new CalculateModelService();

            if (lastInput == "=")
            {
                model.Result = service.CalculateResult();
            }

            if (lastInput == "+")
            {

            }

            if (int.TryParse(lastInput, out int number))
            {

            }

            return View("Calc", model);
        }
    }
}
