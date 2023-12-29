using LiveDinner.Models;
using Microsoft.AspNetCore.Mvc;

namespace LiveDinner.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReservationController : Controller
    {
        private readonly DataContext _context;
        public ReservationController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var reList = _context.Reservations.OrderBy(m => m.ReservationID).ToList();
            return View(reList);
        }
        public IActionResult Delete(int id)
        {
            var deleMenu = _context.Reservations.Find(id);
            if (deleMenu == null)
            {
                return NotFound();
            }
            _context.Reservations.Remove(deleMenu);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
