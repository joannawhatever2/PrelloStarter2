using Microsoft.AspNetCore.Mvc;

namespace PrelloStarter2.Controllers
{
    public class ClientsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
