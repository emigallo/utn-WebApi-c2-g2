using Business.Models;
using Front.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Front.Utils;
using System;

namespace Front.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new TicTacToeViewModel();

            HttpContext.Session.Set<TicTacToeViewModel>("Clave",model);

            return View(model);
        }

        [HttpPost]
        public IActionResult Play(string idButton)
        {
            TicTacToeViewModel model = HttpContext.Session.Get<TicTacToeViewModel>("Clave");

            GameStatus gameStatus = model.TicTacToe.Play(Convert.ToInt32(idButton));

            HttpContext.Session.Set<TicTacToeViewModel>("Clave", model);

            if (gameStatus == GameStatus.Active)
            {
                return View("Index", model);
            }

            return View("Index", model);
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
    }
}
