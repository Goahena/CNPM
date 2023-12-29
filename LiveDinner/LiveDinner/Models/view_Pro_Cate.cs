using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiveDinner.Models
{
	[Table("view_Pro_Cate")]
	public class view_Pro_Cate
	{
		[Key]
		public int ProductID { get; set; }
		public string? ProductName { get; set; }
		public string? Image { get; set; }
		public bool? IsActive { get; set; }
		public int Price { get; set; }
		public string? Description { get; set; }
		public string? Information { get; set; }
		public int? CategoryID { get; set; }
		public Category? Category { get; set; }
		public DateTime? CreatedDate { get; set; }
		public string? CategoryName { get; set; }
		public int? MenuOrder { get; set; }
	}
}
