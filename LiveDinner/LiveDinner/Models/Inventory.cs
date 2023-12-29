using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiveDinner.Models
{
    [Table("tblInventory")]
    public class Inventory
    {
        [Key]
        public int InventoryID { get; set; }
        public string? InventoryName { get; set; }
        public int? Quantity { get; set;}
        public DateTime? DateAdded { get; set; }
        public int ? Price { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool? Status { get; set; }
        public string? Description { get; set; }
    }
}
