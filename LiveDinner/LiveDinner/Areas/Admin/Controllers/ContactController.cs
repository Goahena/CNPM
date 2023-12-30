using LiveDinner.Models;
using Microsoft.AspNetCore.Mvc;

namespace LiveDinner.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;
        private readonly DataContext _context;
        public ContactController(ILogger<ContactController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            var list = _context.Contacts.ToList();
            return View(list);
        }
        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var post = _context.Contacts
                .FirstOrDefault(m => m.ContactID == id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }
        public IActionResult Delete(int id)
        {
            var delete = _context.Contacts.Find(id);
            if (delete == null)
            {
                return NotFound();
            }
            _context.Contacts.Remove(delete);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
