using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrelloStarter3.Models;

namespace PrelloStarter3.Controllers
{
    [Authorize]
    public class ClientsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ClientsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Clients.ToList());
        }

        // Get
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,ClientName,EmailAddress")] Client client)
        {
            if (ModelState.IsValid)
            {
                _db.Clients.Add(client);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var client = _db.Clients.FirstOrDefault(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST
        [HttpPost]
        public IActionResult Delete(int id, bool NotUsed)
        {
            var project = _db.Clients.FirstOrDefault(m => m.Id == id);
            if (project != null)
            {
                _db.Clients.Remove(project);
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
            var project = _db.Clients.FirstOrDefault(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        // POST
        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,ClientName,EmailAddress")] Client client)
        {
            if (ModelState.IsValid)
            {
                if (id != client.Id)
                {
                    return NotFound();
                }

                _db.Clients.Update(client);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(client);
        }
    }
}
