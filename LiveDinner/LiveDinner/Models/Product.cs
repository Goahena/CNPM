using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiveDinner.Models
{
	[Table("tblProduct")]
	public class Product
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
	}
}
