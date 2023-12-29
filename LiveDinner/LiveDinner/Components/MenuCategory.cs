using LiveDinner.Models;
using Microsoft.AspNetCore.Mvc;

namespace FashionWeb.Components
{
	[ViewComponent(Name = "MenuCategory")]
	public class MenuCategory : ViewComponent
	{
		private DataContext _context;
		public MenuCategory(DataContext context)
		{
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var menucategory = (from m in _context.categories
								where (m.IsActive == true)
								select m).ToList();
			return await Task.FromResult((IViewComponentResult)View("Default", menucategory));
		}
	}
}
