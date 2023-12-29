using LiveDinner.Models;
using Microsoft.AspNetCore.Mvc;

namespace LiveDinner.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InventoryController : Controller
    {
        private readonly DataContext _context;
        public InventoryController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var InventoryList = _context.Inventories.OrderBy(m => m.DateAdded).ToList();
            return View(InventoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Inventory inven)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inven);
                _context.SaveChanges();

            }
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var iv = _context.Inventories.Find(id);
            if (iv == null)
            {
                return NotFound();
            }
            return View(iv);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Inventory iv)
        {
            if (ModelState.IsValid)
            {
                _context.Inventories.Update(iv);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(iv);
        }
        public IActionResult Delete(int id)
        {
            var delete = _context.Inventories.Find(id);
            if (delete == null)
            {
                return NotFound();
            }
            _context.Inventories.Remove(delete);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
