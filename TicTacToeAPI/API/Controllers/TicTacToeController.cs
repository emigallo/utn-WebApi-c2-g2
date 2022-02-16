using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TicTacToeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index2()
        {
            return View();
        }
    }
}
