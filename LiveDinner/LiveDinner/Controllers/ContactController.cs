using LiveDinner.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LiveDinner.Controllers
{
    public class ContactController : Controller
    {
        private readonly DataContext _context;
        public ContactController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Contact ct)
        {
            if (ModelState.IsValid)
            {
                _context.Contacts.Add(ct);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
