using Microsoft.AspNetCore.Mvc;
using PrelloStarter2.Models;

namespace PrelloStarter2.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProjectsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Projects.ToList());
        }

        // Get
        public IActionResult Create()
        {
            return View();
        }

        // Next class, 3/31/24 POST for Create!

        public IActionResult Delete()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}
