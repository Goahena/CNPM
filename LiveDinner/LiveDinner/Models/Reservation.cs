using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiveDinner.Models
{
    [Table("tblReservation")]
    public class Reservation
    {
        [Key]
        public int ReservationID { get; set; }
        public string? FullName { get; set;}
        public string? Email { get; set; }
        public string? Number { get; set; }
        public DateTime? DateTime { get; set; }
        public int Person { get; set; }
    }
}
