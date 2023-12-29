using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LiveDinner.Models
{
	[Table("tblGallery")]
	public class Gallery
	{
		[Key]
		public int GalleryID { get; set; }
		public string? ImageName { get; set; }
		public string ImageUrl { get; set;}
		public int OrderBy { get; set; }
		public bool Status { get; set; }
	}
}
