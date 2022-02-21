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
            var model = new TicTacToeViewModel
            {
                Result = "Juega Jugador 1"
            };

            HttpContext.Session.Set<TicTacToeViewModel>("Clave", model);
            
            return View(model);
        }

        [HttpPost]
        public IActionResult Play(string lastInput)
        {
            TicTacToeViewModel model = HttpContext.Session.Get<TicTacToeViewModel>("Clave");

            model.TicTacToe.Board.Positions = model.Positions;
            GameStatus gameStatus = model.TicTacToe.Play(Convert.ToInt32(lastInput));
            model.Positions = model.TicTacToe.Board.GetPositions();

            HttpContext.Session.Set<TicTacToeViewModel>("Clave", model);

            Player player = model.TicTacToe.GetNextPlayer();
            
            if (gameStatus == GameStatus.Active)
            {
                model.Result = "Juega " + player.Name;

                return View("Index", model);
            }
            if (gameStatus == GameStatus.Winner)
            {
                player = model.TicTacToe.GetLastPlayer();
                model.Result = "Ganador " + player.Name;

                return View("Index", model);
            }
            if (gameStatus == GameStatus.PositionHeld)
            {
                model.Result = "Posición ocupada elija otra";

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
