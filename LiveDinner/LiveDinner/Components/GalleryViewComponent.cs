using Microsoft.AspNetCore.Mvc;
using LiveDinner.Models;

namespace LiveDinner.Components
{
	[ViewComponent(Name = "GalleryView")]
	public class GalleryViewComponent : ViewComponent
	{
		private DataContext _context;
		public GalleryViewComponent(DataContext context)
		{
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var listofMenu = (from m in _context.galleries
							  where m.Status == true
							  select m).ToList();

			return await Task.FromResult((IViewComponentResult)View("Default", listofMenu));
		}
	}
}

