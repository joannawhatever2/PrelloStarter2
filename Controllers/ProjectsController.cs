using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrelloStarter3.Models;

namespace PrelloStarter3.Controllers
{
    [Authorize]
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

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,ProjectName,Description,Status,DateDue")] Project project)
        {
            if ( ModelState.IsValid )
            {
                _db.Projects.Add(project);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // GET
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var project = _db.Projects.FirstOrDefault(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        // POST
        [HttpPost]
        public IActionResult Delete(int id, bool NotUsed)
        {
            var project = _db.Projects.FirstOrDefault(m => m.Id == id);
            if (project != null)
            {
                _db.Projects.Remove(project);
                _db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var project = _db.Projects.FirstOrDefault(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        // POST
        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,ProjectName,DateDue,Description,Status")] Project project)
        {
            if (ModelState.IsValid)
            {
                if (id != project.Id)
                {
                    return NotFound();
                }

                _db.Projects.Update(project);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            
            return View(project);
        }
    }
}
