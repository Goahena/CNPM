using LiveDinner.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LiveDinner.Controllers
{
    public class ReservationController : Controller
    {
        private readonly DataContext _context;
        public ReservationController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Reservation re)
        {
            if (ModelState.IsValid)
            {
                _context.Reservations.Add(re);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
