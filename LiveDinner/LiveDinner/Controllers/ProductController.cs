using LiveDinner.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace LiveDinner.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly DataContext _context;
        public ProductController(ILogger<ProductController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index(string keyword)
        {
            var list = _context.view_Pro_Cates
				.Where(m => m.IsActive == true)
                .ToList();
            if (list == null)
            {
                return NotFound();
            }
            return View(list);
        }
        public IActionResult Search(string keyword)
        {
            var lowerKeyword = keyword.ToLower();
            var result = _context.view_Pro_Cates.Where(p => p.ProductName.ToLower().Contains(lowerKeyword)).ToList();

            return View("Index",result);
        }
        public IActionResult CategorySearch(int? CategoryID)
        {
            if (CategoryID == null || CategoryID == 0)
            {
                return NotFound();
            }
            var ct = _context.Products
                .Where(m => m.CategoryID == CategoryID).ToList();
            if (ct == null)
            {
                return NotFound();
            }
            return View(ct);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = _context.Products
                .FirstOrDefault(m => (m.ProductID == id));
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}
