using LiveDinner.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LiveDinner.Controllers
{
    public class BlogController : Controller
    {
        private readonly ILogger<BlogController> _logger;
        private readonly DataContext _context;
        public BlogController(ILogger<BlogController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            var list = _context.Posts
                .Where(m => m.IsActive == true)
                .ToList();
            if (list == null)
            {
                return NotFound();
            }
            return View(list);
        }
        [Route("/post-{slug}-{id:long}.html", Name = "Details")]
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var post = _context.Posts
                .FirstOrDefault(m => (m.PostID == id) && (m.IsActive == true));
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }
        public IActionResult Search(string keyword)
        {
            var lowerKeyword = keyword.ToLower();
            var result = _context.Posts.Where(p => p.Title.ToLower().Contains(lowerKeyword)).ToList();

            return View("Index", result);
        }
    }
}
